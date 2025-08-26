using Microsoft.AspNetCore.Components.Authorization;
using SolutionExplorer.KMS.SharedUI.Dtos;
using SolutionExplorer.KMS.SharedUI.Dtos.UserDtos;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;
using System.Security.Claims;

namespace SolutionExplorer.KMS.SharedUI.Services.Implementations
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IHttpService _httpService;
        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(
            ILocalStorageService localStorage,
            IHttpService httpService)
        {
            _localStorage = localStorage;
            _httpService = httpService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(_anonymous);
            }

            var result = await _httpService.GetAsync<ApiResult<string>>("api/User/CheckTokenValidation");
            if (result?.IsSuccess == true && !String.IsNullOrEmpty(result.Data))
            {
                // ساخت claims و بازگردانی وضعیت معتبر
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.Data),
                    new Claim("Token", token)
                };

                var identity = new ClaimsIdentity(claims, "apiauth");
                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }

            // اگر توکن معتبر نبود، پاکش کن
            await _localStorage.RemoveItemAsync("authToken");
            return new AuthenticationState(_anonymous);
        }

        public void NotifyUserAuthentication(ClaimsPrincipal user)
        {
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }

        public void NotifyUserLogout()
        {
            var state = new AuthenticationState(_anonymous);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }
    }
}

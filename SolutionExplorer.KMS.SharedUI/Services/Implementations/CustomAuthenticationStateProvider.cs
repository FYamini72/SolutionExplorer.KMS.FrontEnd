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

            var result = await _httpService.GetAsync<ApiResult<UserAndTokenDisplayDto>>("api/User/CheckTokenValidation");
            if (result?.IsSuccess == true && result.Data != null)
            {
                // ساخت claims و بازگردانی وضعیت معتبر
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.Data.UserName),
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

        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    var token = await _localStorage.GetItemAsync<string>("authToken");
        //    if (string.IsNullOrEmpty(token))
        //    {
        //        return new AuthenticationState(_anonymous);
        //    }

        //    var result = await _httpService.GetAsync<ApiResult<UserAndTokenDisplayDto>>("api/User/CheckTokenValidation");
        //    if (result?.IsSuccess == true && result.Data != null)
        //    {
        //        var user = result.Data;
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim("Token", token)
        //        };

        //        // اضافه کردن نقش‌ها (اگر داشتید)
        //        if (user.UserRoles != null)
        //        {
        //            foreach (var role in user.UserRoles)
        //            {
        //                claims.Add(new Claim(ClaimTypes.Role, role.RoleTitle));
        //            }
        //        }

        //        var claimsIdentity = new ClaimsIdentity(claims, "apiauth");
        //        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        //        return new AuthenticationState(claimsPrincipal);
        //    }

        //    // اگر توکن معتبر نبود، پاکش کن
        //    await _localStorage.RemoveItemAsync("authToken");
        //    return new AuthenticationState(_anonymous);
        //}

        // فراخوانی این متد وقتی که وضعیت تغییر می‌کند (مثلاً بعد از لاگین/لاگ‌اوت)
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

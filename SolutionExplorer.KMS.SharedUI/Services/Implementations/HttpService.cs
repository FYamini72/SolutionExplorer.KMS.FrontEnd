using Newtonsoft.Json;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;

namespace SolutionExplorer.KMS.SharedUI.Services.Implementations
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _baseUrl;

        public HttpService(HttpClient httpClient)
        {
            _baseUrl = "https://localhost:7180/";
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<TResponse?> GetByFilterAsync<TRequest, TResponse>(string endpoint, TRequest model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + endpoint);
            var serializedModel = JsonConvert.SerializeObject(model);
            var content = new StringContent(serializedModel, System.Text.Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseContent ?? "") ?? default(TResponse);
            }
            return default(TResponse);
        }

        /// <inheritdoc />
        public async Task<TResponse?> GetAsync<TResponse>(string endPoint)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + endPoint);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(content) ?? default(TResponse);
            }
            return default(TResponse);
        }

        /// <inheritdoc />
        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endPoint, TRequest model)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, _baseUrl + endPoint);
            var serializedModel = JsonConvert.SerializeObject(model);
            var content = new StringContent(serializedModel, System.Text.Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseContent ?? "") ?? default(TResponse);
            }
            return default(TResponse);
        }

        /// <inheritdoc />
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endPoint, TRequest model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + endPoint);
            var serializedModel = JsonConvert.SerializeObject(model);
            var content = new StringContent(serializedModel, System.Text.Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseContent ?? "") ?? default(TResponse);
            }
            return default(TResponse);
        }
    }

    public class SpinnerService// : ISpinnerService
    {
        public event Action OnShow;
        public event Action OnHide;

        public void Show()
        {
            OnShow?.Invoke();
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }
    }
}

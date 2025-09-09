using Newtonsoft.Json;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;
using System.Net.Http.Headers;

namespace SolutionExplorer.KMS.SharedUI.Services.Implementations
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _baseUrl;
        private readonly ILocalStorageService _localStorageService;

        public HttpService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _baseUrl = "http://185.7.212.79:5000/";
            //_baseUrl = "http://185.7.212.79:9091/";
            //_baseUrl = "https://localhost:7180/";
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        /// <inheritdoc />
        public async Task<TResponse?> GetByFilterAsync<TRequest, TResponse>(string endpoint, TRequest model, bool addAuthToken = true)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + endpoint);

            if (addAuthToken)
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

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
        public async Task<TResponse?> GetAsync<TResponse>(string endPoint, bool addAuthToken = true)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + endPoint);

            if (addAuthToken)
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(content) ?? default(TResponse);
            }
            return default(TResponse);
        }

        /// <inheritdoc />
        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endPoint, TRequest model, bool addAuthToken = true)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, _baseUrl + endPoint);

            if (addAuthToken)
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

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
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endPoint, TRequest model, bool addAuthToken = true)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + endPoint);

            if (addAuthToken)
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

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
}

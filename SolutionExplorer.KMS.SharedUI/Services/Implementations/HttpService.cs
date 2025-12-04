using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;

namespace SolutionExplorer.KMS.SharedUI.Services.Implementations
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _baseUrl;
        private readonly ILocalStorageService _localStorageService;

        public HttpService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _baseUrl = "https://localhost:7180/";
            //_baseUrl = "http://45.149.77.107:8586/";
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

        /// <inheritdoc />
        public async Task<TResponse?> DeleteAsync<TResponse>(string endPoint, bool addAuthToken = true)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, _baseUrl + endPoint);

            if (addAuthToken)
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseContent ?? "") ?? default(TResponse);
            }
            return default(TResponse);
        }

        /// <inheritdoc />
        public async Task<TResponse?> PostMultipartAsync<TRequest, TResponse>(
            string endpoint,
            TRequest model,
            int maxSize = 20,
            bool addAuthToken = true)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            using var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + endpoint);
            using var multipart = new MultipartFormDataContent();

            // افزودن توکن احراز هویت در صورت نیاز
            if (addAuthToken)
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (!string.IsNullOrWhiteSpace(token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // تابع کمکی برای افزودن مقدار متنی
            void AddStringField(string name, object? value)
            {
                if (value == null) return;
                multipart.Add(new StringContent(value.ToString()!, System.Text.Encoding.UTF8), name);
            }

            var props = typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var value = prop.GetValue(model);
                if (value == null) continue;

                // اگر پراپرتی از نوع BaseFileInfo بود، فایل را استخراج کن
                var propType = prop.PropertyType;
                if (!propType.IsPrimitive && propType != typeof(string))
                {
                    var subProps = propType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var bytesProp = subProps.FirstOrDefault(p => p.Name.Equals("SelectedFileBytes", StringComparison.OrdinalIgnoreCase));
                    var nameProp = subProps.FirstOrDefault(p => p.Name.Equals("SelectedFileName", StringComparison.OrdinalIgnoreCase));
                    var contentTypeProp = subProps.FirstOrDefault(p => p.Name.Equals("SelectedFileContentType", StringComparison.OrdinalIgnoreCase));

                    var fileBytes = bytesProp?.GetValue(value) as byte[];
                    var fileName = nameProp?.GetValue(value)?.ToString() ?? "file.bin";
                    var contentType = contentTypeProp?.GetValue(value)?.ToString() ?? "application/octet-stream";

                    if (fileBytes != null && fileBytes.Length > 0)
                    {
                        if (fileBytes.Length > maxSize * 1024L * 1024L)
                            throw new InvalidOperationException($"حجم فایل {fileName} بیش از {maxSize} مگابایت است.");

                        var fileContent = new ByteArrayContent(fileBytes);
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                        multipart.Add(fileContent, prop.Name, fileName);
                        continue;
                    }
                }

                // مقادیر متنی و ساده
                AddStringField(prop.Name, value);
            }

            request.Content = multipart;

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return default;

            if (string.IsNullOrWhiteSpace(json))
                return default;

            return JsonConvert.DeserializeObject<TResponse>(json);
        }

        /// <inheritdoc />
        public async Task<TResponse?> PutMultipartAsync<TRequest, TResponse>(
            string endpoint,
            TRequest model,
            int maxSize = 20,
            bool addAuthToken = true)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            using var request = new HttpRequestMessage(HttpMethod.Put, _baseUrl + endpoint);
            using var multipart = new MultipartFormDataContent();

            // افزودن توکن احراز هویت در صورت نیاز
            if (addAuthToken)
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (!string.IsNullOrWhiteSpace(token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // تابع کمکی برای افزودن مقدار متنی
            void AddStringField(string name, object? value)
            {
                if (value == null) return;
                multipart.Add(new StringContent(value.ToString()!, System.Text.Encoding.UTF8), name);
            }

            var props = typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var value = prop.GetValue(model);
                if (value == null) continue;

                // اگر پراپرتی از نوع BaseFileInfo بود، فایل را استخراج کن
                var propType = prop.PropertyType;
                if (!propType.IsPrimitive && propType != typeof(string))
                {
                    var subProps = propType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var bytesProp = subProps.FirstOrDefault(p => p.Name.Equals("SelectedFileBytes", StringComparison.OrdinalIgnoreCase));
                    var nameProp = subProps.FirstOrDefault(p => p.Name.Equals("SelectedFileName", StringComparison.OrdinalIgnoreCase));
                    var contentTypeProp = subProps.FirstOrDefault(p => p.Name.Equals("SelectedFileContentType", StringComparison.OrdinalIgnoreCase));

                    var fileBytes = bytesProp?.GetValue(value) as byte[];
                    var fileName = nameProp?.GetValue(value)?.ToString() ?? "file.bin";
                    var contentType = contentTypeProp?.GetValue(value)?.ToString() ?? "application/octet-stream";

                    if (fileBytes != null && fileBytes.Length > 0)
                    {
                        if (fileBytes.Length > maxSize * 1024L * 1024L)
                            throw new InvalidOperationException($"حجم فایل {fileName} بیش از {maxSize} مگابایت است.");

                        var fileContent = new ByteArrayContent(fileBytes);
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                        multipart.Add(fileContent, prop.Name, fileName);
                        continue;
                    }
                }

                // مقادیر متنی و ساده
                AddStringField(prop.Name, value);
            }

            request.Content = multipart;

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return default;

            if (string.IsNullOrWhiteSpace(json))
                return default;

            return JsonConvert.DeserializeObject<TResponse>(json);
        }

        public async Task<byte[]?> DownloadFileAsync(string endpoint, bool addAuthToken = true)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + endpoint);

            if (addAuthToken)
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (!string.IsNullOrEmpty(token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}

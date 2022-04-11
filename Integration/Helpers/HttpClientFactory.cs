using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ANUPayments.Models;
using Newtonsoft.Json;

namespace ANUPayments.Helpers
{
    internal class HttpClientFactory
    {
        private readonly HttpClient _httpClient;
        private const string BaseUri = "https://api.upayments.com/";

        public HttpClientFactory(string xHeader, Mode apiMode = Mode.Staging)
        {
            var apiVersion = apiMode == Mode.Production ? "payment-request" : "test-payment";
            _httpClient = new HttpClient { BaseAddress = new Uri($"{BaseUri}{apiVersion}") };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-Authorization", xHeader);
        }


        public async Task<GenericResponse<T, TU>> GetAsync<T, TU>(string endpoint, string args = null)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?{args}");
            var result = new GenericResponse<T, TU>
            {
                IsSuccess = response.IsSuccessStatusCode
            };
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (result.IsSuccess)
                result.SuccessResponse = JsonConvert.DeserializeObject<T>(jsonResponse);
            else
                result.FailureResponse = JsonConvert.DeserializeObject<TU>(jsonResponse);
            return result;
        }

        public async Task<GenericResponse<T, TU>> PostFormAsync<T, TU>(string endpoint,
            FormUrlEncodedContent formContent)
        {
            var response = await _httpClient.PostAsync($"{endpoint}", formContent);
            var result = new GenericResponse<T, TU>
            {
                IsSuccess = response.IsSuccessStatusCode
            };
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (result.IsSuccess)
                result.SuccessResponse = JsonConvert.DeserializeObject<T>(jsonResponse);
            else
                result.FailureResponse = JsonConvert.DeserializeObject<TU>(jsonResponse);
            return result;
        }


        public async Task<GenericResponse<T, TU>> PostAsync<T, TU>(string endpoint, object jObject)
        {
            var json = JsonConvert.SerializeObject(jObject);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{endpoint}", httpContent);
            var result = new GenericResponse<T, TU>
            {
                JsonRequest = json,
                IsSuccess = response.IsSuccessStatusCode
            };
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (result.IsSuccess)
                result.SuccessResponse = JsonConvert.DeserializeObject<T>(jsonResponse);
            else
                result.FailureResponse = JsonConvert.DeserializeObject<TU>(jsonResponse);

            return result;
        }
    }
}
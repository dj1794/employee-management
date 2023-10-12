using HrmUi.IService;
using HrmUi.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace HrmUi.Service
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        public string relativeUrl { get; set; } = "/api/v1/";
        public ApiService(HttpClient httpClient)
        {

            this._httpClient = httpClient;
        }
        public async Task<bool> DeleteAsync<T>(string endpoint)
        {
            var response = await _httpClient.DeleteAsync(endpoint);
            return response.IsSuccessStatusCode;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetFromJsonAsync<T>(endpoint);
            return response;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string endpoint)
        {
           var response = await _httpClient.GetFromJsonAsync<T[]>(endpoint);
            return response;
        }

        public async Task<T> PostAsync<T>(string endpoint,T TRequest)
        {
           var response = await _httpClient.PostAsJsonAsync<T>( $"{relativeUrl}{endpoint}", TRequest);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var returnModel = JsonConvert.DeserializeObject<T>(result);
                return returnModel;
            }
            else
            {
                throw new Exception
                    ($"Failed to retrieve items returned {response.StatusCode}");
            }
        }

        public async Task<T> PutAsync<T>(string endpoint, T TRequest)
        {
            var response = await _httpClient.PutAsJsonAsync(endpoint, TRequest);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var returnModel = JsonConvert.DeserializeObject<T>(result);
                return returnModel;
            }
            else
            {
                throw new Exception
                    ($"Failed to retrieve items returned {response.StatusCode}");
            }
        }
    }
}

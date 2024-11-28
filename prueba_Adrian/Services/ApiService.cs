using prueba_Adrian.DataAccess;
using prueba_Adrian.Models;
using System.Net.Http;

namespace prueba_Adrian.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DataBank>> FetchApiDataAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DataBank>>("https://api.opendata.esett.com/EXP06/Banks");
            return response ?? new List<DataBank>();
        }
    }
}

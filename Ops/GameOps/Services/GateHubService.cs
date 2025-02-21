using OpsCommon;
using System.Net.Http.Json;
using System.Text;

namespace GameOps.Services
{
    public class GateHubService(HttpClient httpClient)
    {
        private HttpClient _httpClient = httpClient;

        public async Task CreateAsync(Gate gate)
        {
            await _httpClient.PostAsJsonAsync("/create", gate);
        }

        public async Task<List<Gate>> GetListAsync()
        {
            var response = await _httpClient.PostAsync("/list", null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Gate>>() ?? [];
            }

            return [];
        }

        public async Task UpdateAsync(Gate gate)
        {
            await _httpClient.PostAsJsonAsync("/update", gate);
        }

        public async Task DeleteAsync(string version)
        {
            var content = new StringContent($"\"{version}\"", Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("/delete", content);
        }

        public async Task<string> GateHubAsync(string version)
        {
            var content = new StringContent($"\"{version}\"", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/gatehub", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }
    }
}

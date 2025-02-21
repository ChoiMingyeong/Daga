using OpsCommon;
using System.Net.Http.Json;

namespace GameOps.Services
{
    public class DBService(HttpClient httpClient)
    {
        private HttpClient _httpClient = httpClient;

        public async Task<Account?> LoginAsync(Login login)
        {
            var response = await _httpClient.PostAsJsonAsync("/account/login", login);
            if(response.IsSuccessStatusCode)
            {
                var account = await response.Content.ReadFromJsonAsync<Account>();
                return account;
            }

            return null;
        }
    }
}
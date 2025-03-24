using DagaCommon.Models;
using System.Net.Http.Json;

namespace DagaTools.Services
{
    public partial class DBService
    {
        public async Task<Account?> LoginAsync(Login data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/auth/login", data);
                if (response.IsSuccessStatusCode)
                {
                    var account = await response.Content.ReadFromJsonAsync<Account>();
                    return account;
                }
            }
            catch
            {
                return null;
            }

            return null;
        }
    }
}

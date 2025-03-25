using DagaCommon.Models;
using DagaCommon.Protocol;
using System.Net.Http.Json;

namespace DagaTools.Services
{
    public partial class DBService
    {
        public async Task<Account?> LoginAsync(LoginModel data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/auth/login", new RequestLogin()
                {
                    Email = data.Email,
                    Password = data.Password
                });

                if (response.IsSuccessStatusCode)
                {
                    var recPacket = await response.Content.ReadFromJsonAsync<ResponseLogin>();
                    if (null == recPacket)
                    {
                        return null;
                    }

                    return new Account()
                    {
                        ID = recPacket.AccountID,
                        Name = recPacket.Name,
                        Projects = recPacket.Projects,
                    };
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public async Task<bool> SignupAsync(SignupModel data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/auth/signup", data);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}

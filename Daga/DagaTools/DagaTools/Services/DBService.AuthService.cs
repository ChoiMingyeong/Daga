using DagaCommon.Models;
using DagaCommon.Protocol;
using DagaTools.Models;
using System.Net.Http.Json;

namespace DagaTools.Services
{
    public partial class DBService
    {
        public async Task<Account?> LoginAsync(string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/auth/login", new RequestLogin()
                {
                    Email = email,
                    Password = password
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
                var response = await _httpClient.PostAsJsonAsync("/auth/signup", new RequestSignup()
                {
                    Email = data.Email,
                    Password = data.Password,
                    Name = data.Name,
                });
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SendEmailVerificationCodeAsync(string email)
        {
            return true;
        }

        public async Task<bool> VerifyCodeAsync(string code)
        {
            return true;
        }

        public async Task<List<Project>?> GetProjectsAsync(uint accountID)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/project?accountID={accountID}");
                if (response.IsSuccessStatusCode)
                {
                    var projects = await response.Content.ReadFromJsonAsync<List<Project>>();
                    if (null == projects)
                    {
                        return null;
                    }

                    return projects;
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public async Task<bool> CreateProjectAsync(uint accountID, string projectName, string projectDescription)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/project", new RequestCreateProject()
                {
                    AccountID = accountID,
                    ProjectName = projectName,
                    ProjectDescription = projectDescription,
                });

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateProjectFavoriteAsync(uint accountID, ulong projectID, bool favorite)
        {
            try
            {
                var response = await _httpClient.PatchAsJsonAsync("/project", new RequestUpdateProjectFavorite()
                {
                    AccountID = accountID,
                    ProjectID = projectID,
                    Favorite = favorite,
                });

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}

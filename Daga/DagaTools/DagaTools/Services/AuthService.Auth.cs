using DagaCommon.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace DagaTools.Services
{
    public partial class AuthService
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _claimsPrincipal = AnonymousPrincipal;
            if (null == Account)
            {
                var accountJson = await _sessionStorageService.GetItemAsStringAsync(nameof(Account));
                if (false == string.IsNullOrEmpty(accountJson)
                    && JsonSerializer.Deserialize<Account>(accountJson) is Account account)
                {
                    Account = account;
                    _claimsPrincipal = new(new ClaimsIdentity([new Claim(ClaimTypes.Name, Account.Name)], "apiauth_type"));
                    await LoadProjectsAsync();
                }
            }

            return new AuthenticationState(_claimsPrincipal);
        }

        public async Task<bool> LoginAsync(LoginModel data)
        {
            Account = await _dbService.LoginAsync(data);
            if (null == Account)
            {
                Projects.Clear();
                _claimsPrincipal = AnonymousPrincipal;
                return false;
            }

            _claimsPrincipal = new(new ClaimsIdentity([new Claim(ClaimTypes.Name, Account.Name)], "apiauth_type"));
            await _sessionStorageService.SetItemAsStringAsync(nameof(Account), JsonSerializer.Serialize(Account));

            await LoadProjectsAsync();

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return true;
        }

        public async Task LogoutAsync()
        {
            Account = null;
            _claimsPrincipal = AnonymousPrincipal;
            await _sessionStorageService.RemoveItemAsync(nameof(Account));

            await LoadProjectsAsync();

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<bool> SignupAsync(SignupModel data)
        {
            return await _dbService.SignupAsync(data);
        }
    }
}

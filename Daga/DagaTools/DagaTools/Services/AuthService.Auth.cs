using DagaCommon.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;

namespace DagaTools.Services
{
    public partial class AuthService
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (null == _account)
            {
                var accountJson = await _sessionStorageService.GetItemAsStringAsync(nameof(Account));
                if (false == string.IsNullOrEmpty(accountJson)
                    && JsonSerializer.Deserialize<Account>(accountJson) is Account account)
                {
                    _account = account;
                }
            }

            return new AuthenticationState(Principal);
        }

        public async Task<Account?> MarkUserAsAuthenticated(Login login)
        {
            _account = await _dbService.LoginAsync(login);
            if (null == _account)
            {
                return null;
            }

            await _sessionStorageService.SetItemAsStringAsync(nameof(Account), JsonSerializer.Serialize(_account));
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            return _account;
        }

        public async Task MarkUseAsLoggedOut()
        {
            _account = null;
            await _sessionStorageService.RemoveItemAsync(nameof(Account));
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}

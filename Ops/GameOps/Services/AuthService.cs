using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OpsCommon;
using System.Security.Claims;

namespace GameOps.Services
{
    public class AuthService : AuthenticationStateProvider
    {
        private readonly DBService _dbService;
        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsPrincipal? _currentUser = null;

        public AuthService(DBService dbService, ISessionStorageService sessionStorageService)
        {
            _dbService = dbService;
            _sessionStorageService = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (null == _currentUser)
            {
                var account = await _sessionStorageService.GetItemAsync<Account>(ClaimTypes.Sid);
                if (account != null)
                {
                    _currentUser = new ClaimsPrincipal(new ClaimsIdentity([
                        new Claim(ClaimTypes.Name, account.Name),
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.Sid, account.Id.ToString()),
                    ], "apiauth_type"));
                }
                else
                {
                    _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
                }
            }

            return new AuthenticationState(_currentUser);
        }

        public async Task<Account?> MarkUserAsAuthenticated(Login login)
        {
            var account = await _dbService.LoginAsync(login);
            if (null == account)
            {
                return null;
            }

            _currentUser = new ClaimsPrincipal(new ClaimsIdentity([
                new Claim(ClaimTypes.Name, account.Name),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Sid, account.Id.ToString()),
            ], "apiauth_type"));
            await _sessionStorageService.SetItemAsync(ClaimTypes.Sid, account);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            return account;
        }

        public async Task MarkUseAsLoggedOut()
        {
            _currentUser = null;
            await _sessionStorageService.RemoveItemAsync(ClaimTypes.Sid);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}

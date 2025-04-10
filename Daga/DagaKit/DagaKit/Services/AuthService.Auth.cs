using DagaCommon.Models;
using DagaKit.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;

namespace DagaKit.Services
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
                    await LoadProjectsAsync();
                }
            }

            return new AuthenticationState(_claimsPrincipal);
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            if (await _dbService.LoginAsync(email, password) is not Account account)
            {
                return false;
            }

            Account = account;
            await LoadProjectsAsync();
            await _sessionStorageService.SetItemAsStringAsync(nameof(Account), JsonSerializer.Serialize(Account));

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return true;
        }

        public async Task LogoutAsync()
        {
            Account = null;
            await _sessionStorageService.RemoveItemAsync(nameof(Account));
            
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<bool> SignupAsync(SignupModel data)
        {
            return await _dbService.SignupAsync(data);
        }

        public async Task<bool> SendEmailVerificationCodeAsync(string email)
        {
            return await _dbService.SendEmailVerificationCodeAsync(email);
        }

        public async Task<bool> VerifyCodeAsync(string code)
        {
            return await _dbService.VerifyCodeAsync(code);
        }
    }
}

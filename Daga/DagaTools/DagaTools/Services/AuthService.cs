using Blazored.SessionStorage;
using DagaCommon.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace DagaTools.Services
{
    public partial class AuthService : AuthenticationStateProvider
    {
        private static readonly ClaimsPrincipal Anonymous = new();
        private static readonly ClaimsPrincipal Authenticated = new(new ClaimsIdentity("apiauth_type"));

        private readonly DBService _dbService;
        private readonly ISessionStorageService _sessionStorageService;

        public Account? Account { get => _account; }
        private Account? _account = null;

        private ClaimsPrincipal Principal { get => null == _account ? Anonymous : Authenticated; }

        public AuthService(DBService dbService, ISessionStorageService sessionStorageService)
        {
            _dbService = dbService;
            _sessionStorageService = sessionStorageService;
        }
    }
}

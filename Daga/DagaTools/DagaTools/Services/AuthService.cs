using Blazored.SessionStorage;
using DagaCommon.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace DagaTools.Services
{
    public partial class AuthService : AuthenticationStateProvider
    {
        private static readonly ClaimsPrincipal AnonymousPrincipal = new();

        private readonly DBService _dbService;
        private readonly ISessionStorageService _sessionStorageService;

        private Account? _account = null;
        public Account? Account
        {
            get
            {
                return _account;
            }
            private set
            {
                if (null == value)
                {
                    _claimsPrincipal = AnonymousPrincipal;
                }
                else
                {
                    _claimsPrincipal = new(new ClaimsIdentity([new Claim(ClaimTypes.Name, value.Name)], "apiauth_type"));
                }

                _account = value;
                Projects.Clear();
            }
        }
        public List<Project> Projects { get; private set; } = [];

        private ClaimsPrincipal _claimsPrincipal = AnonymousPrincipal;

        public AuthService(DBService dbService, ISessionStorageService sessionStorageService)
        {
            _dbService = dbService;
            _sessionStorageService = sessionStorageService;
        }
    }
}

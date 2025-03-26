﻿using Blazored.SessionStorage;
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

        public Account? Account { get; private set; } = null;
        public List<Project> Projects { get; private set; } = [];

        private ClaimsPrincipal? _claimsPrincipal = null;

        public AuthService(DBService dbService, ISessionStorageService sessionStorageService)
        {
            _dbService = dbService;
            _sessionStorageService = sessionStorageService;
        }
    }
}

using DagaCommon.Models;
using System.Security.Claims;

namespace DagaTools.Services
{
    public partial class AuthService
    {
        public readonly Account? Account;
        private ClaimsPrincipal _principal = new();
    }
}

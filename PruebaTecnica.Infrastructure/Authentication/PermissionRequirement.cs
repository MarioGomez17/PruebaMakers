using Microsoft.AspNetCore.Authorization;

namespace PruebaTecnica.Infrastructure.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }
        public PermissionRequirement(string Permission)
        {
            this.Permission = Permission;
        }
    }
}

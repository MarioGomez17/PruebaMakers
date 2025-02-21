using Microsoft.AspNetCore.Authorization;
using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Authentication
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(PermissionEnum Permission) : base(policy: Permission.ToString())
        { }
    }
}

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PruebaTecnica.Infrastructure.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext Context, PermissionRequirement Requirement)
        {
            string? UserId = Context.User.Claims.FirstOrDefault(Claim => Claim.Type == ClaimTypes.NameIdentifier)?.Value;
            if (UserId is null)
            {
                return Task.CompletedTask;
            }
            HashSet<string> Permissions = Context.User.Claims.Where(Claim => Claim.Type == CustomClaims.Permission).Select(Claim => Claim.Value).ToHashSet();
            if (Permissions.Contains(Requirement.Permission))
            {
                Context.Succeed(Requirement);
            }
            return Task.CompletedTask;
        }
    }
}

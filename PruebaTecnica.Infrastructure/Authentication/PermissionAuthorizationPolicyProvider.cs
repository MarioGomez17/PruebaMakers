using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace PruebaTecnica.Infrastructure.Authentication
{
    public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> Options) : base(Options)
        { }
        public override async Task<AuthorizationPolicy?> GetPolicyAsync(string PolicyName)
        {
            AuthorizationPolicy? Policy = await base.GetPolicyAsync(PolicyName);
            if (Policy is not null)
            {
                return Policy;
            }
            return new AuthorizationPolicyBuilder().AddRequirements(new PermissionRequirement(PolicyName)).Build();
        }
    }
}

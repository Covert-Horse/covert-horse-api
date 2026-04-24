using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Covert.Horse.Api.Security
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirements>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasScopeRequirements requirement)
        {
            // If user has no claims, stop
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
            {
                return Task.CompletedTask;
            }

            // Get scopes
            var scopes = context.User
                .FindAll(c => c.Type == "scope" && c.Issuer == requirement.Issuer)
                .SelectMany(c => c.Value.Split(' '));

            // Check if required scope exists
            if (scopes.Any(s => s == requirement.Scope))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
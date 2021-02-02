using System.Threading.Tasks;
using FinancialSystem.WebApi.ApiKey.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace FinancialSystem.WebApi.ApiKey
{
    public class AuthorizationHandler : AuthorizationHandler<IAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement)
        {
            var role = requirement is OnlyAdminsRequirement ? Roles.Admin : Roles.User;

            if (context.User.IsInRole(role))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
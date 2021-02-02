using Microsoft.AspNetCore.Authorization;

namespace FinancialSystem.WebApi.ApiKey.Requirements
{
    public class OnlyAdminsRequirement : IAuthorizationRequirement
    {
    }
}
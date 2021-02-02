using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FinancialSystem.WebApi.ApiKeyAuthorization
{
    public class ApiKeyRequirement : IAuthorizationRequirement
    {
        public IReadOnlyList<ApiKey> ApiKeys { get; set; }

        public ApiKeyRequirement(IEnumerable<ApiKey> apiKeys)
        {
            ApiKeys = apiKeys?.ToList() ?? new List<ApiKey>();
        }
    }
}

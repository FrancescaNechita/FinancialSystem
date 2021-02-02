using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialSystem.WebApi.ApiKey
{
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> apiKeys;

        public InMemoryGetApiKeyQuery()
        {
            var existingApiKeys = new List<ApiKey>
            {
                new ApiKey("1", "admin123", new List<string> { Roles.Admin, Roles.User }),
                new ApiKey("2", "admin345", new List<string> { Roles.Admin, Roles.User }),
                new ApiKey("3", "user123", new List<string> { Roles.User }),
                new ApiKey("4", "user345", new List<string> { Roles.User })
            };

            apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
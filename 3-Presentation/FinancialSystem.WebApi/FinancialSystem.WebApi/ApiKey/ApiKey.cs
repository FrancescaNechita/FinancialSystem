using System;
using System.Collections.Generic;

namespace FinancialSystem.WebApi.ApiKey
{
    public class ApiKey
    {
        public ApiKey(string userId, string key, IReadOnlyCollection<string> roles)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        public string UserId { get; }
        public string Key { get; }
        public IReadOnlyCollection<string> Roles { get; }
    }
}
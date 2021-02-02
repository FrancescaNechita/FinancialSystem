using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialSystem.WebApi.ApiKeyAuthorization
{
    public class ApiKey
    {
        public string Key { get; set; }
        public string UserId { get; set; }

        public ApiKey(string key, string userId)
        {
            Key = key;
            UserId = userId;
        }
    }
}

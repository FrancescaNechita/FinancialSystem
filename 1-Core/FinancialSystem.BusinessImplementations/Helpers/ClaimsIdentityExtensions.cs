using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace FinancialSystem.WebApi.Helpers
{
    public static class ClaimsIdentityExtensions
    {
        internal static int GetUserId(this IPrincipal currentPrincipal)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            var claim = identity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return int.Parse(claim?.Value);
        }
    }
}
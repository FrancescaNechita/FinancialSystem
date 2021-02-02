using FinancialSystem.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace FinancialSystem.WebApi.Configurations
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

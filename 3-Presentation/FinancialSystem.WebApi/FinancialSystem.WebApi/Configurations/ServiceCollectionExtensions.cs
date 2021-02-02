using System.Security.Principal;
using FinancialSystem.WebApi.ApiKey;
using FinancialSystem.WebApi.ApiKey.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialSystem.WebApi.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiIoc(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IPrincipal>(
                (sp) => sp.GetService<IHttpContextAccessor>().HttpContext.User);
        }

        public static void AddAuthenticationAndAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                    options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                })
                .AddApiKeySupport(options => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.OnlyAdmins, policy => policy.Requirements.Add(new OnlyAdminsRequirement()));
                options.AddPolicy(Policies.AllUsers, policy => policy.Requirements.Add(new AllUsersRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, AuthorizationHandler>();
            services.AddSingleton<IGetApiKeyQuery, InMemoryGetApiKeyQuery>();
        }
    }
}
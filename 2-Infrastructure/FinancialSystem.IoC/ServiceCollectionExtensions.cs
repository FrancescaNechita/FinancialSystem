using FinancialSystem.BusinessImplementations.Configurations.Ioc;
using FinancialSystem.DataAccess.Configurations.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialSystem.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddIoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddDataAccess(configuration.GetConnectionString("FinancialSystem"));
            services.AddBusiness();
        }
    }
}
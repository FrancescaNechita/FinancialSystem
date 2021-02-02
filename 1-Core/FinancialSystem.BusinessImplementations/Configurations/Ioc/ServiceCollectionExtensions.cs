using FinancialSystem.BusinessContracts.Invoices;
using FinancialSystem.BusinessImplementations.Invoices;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialSystem.BusinessImplementations.Configurations.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceNoteService, InvoiceNoteService>();
        }
    }
}
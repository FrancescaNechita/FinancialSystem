using FinancialSystem.DataAccess.Context;
using FinancialSystem.DataAccess.Repositories.Invoices;
using FinancialSystem.Domain.Invoices.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialSystem.DataAccess.Configurations.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName, AppDatabase.DefaultSchema)));

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceNoteRepository, InvoiceNoteRepository>();
        }
    }
}

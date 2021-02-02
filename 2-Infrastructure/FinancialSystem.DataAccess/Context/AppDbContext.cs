using FinancialSystem.DataAccess.Configurations;
using FinancialSystem.DataAccess.EntityConfiguration.Invoices;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystem.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(AppDatabase.DefaultSchema);

            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceNoteConfiguration());
        }
    }
}
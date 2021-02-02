using FinancialSystem.Domain.Invoices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialSystem.DataAccess.EntityConfiguration.Invoices
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Identifier).IsRequired()
                .HasMaxLength(64).IsUnicode(false);
            builder.Property(x => x.Amount).IsRequired().HasPrecision(10, 2);

            builder.Property(x => x.UserId).IsRequired();
        }
    }
}

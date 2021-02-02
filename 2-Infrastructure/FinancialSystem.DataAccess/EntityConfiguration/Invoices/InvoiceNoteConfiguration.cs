using FinancialSystem.Domain.Invoices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialSystem.DataAccess.EntityConfiguration.Invoices
{
    internal class InvoiceNoteConfiguration : IEntityTypeConfiguration<InvoiceNote>
    {
        public void Configure(EntityTypeBuilder<InvoiceNote> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Text).IsRequired()
                .HasMaxLength(256).IsUnicode(false);

            builder.HasOne<Invoice>()
                .WithMany()
                .HasForeignKey(x => x.InvoiceId);

            builder.Property(x => x.UserId).IsRequired();
        }
    }
}

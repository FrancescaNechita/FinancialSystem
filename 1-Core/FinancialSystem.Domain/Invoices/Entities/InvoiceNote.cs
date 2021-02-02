using FinancialSystem.Domain.Base;

namespace FinancialSystem.Domain.Invoices.Entities
{
    public class InvoiceNote : BaseEntity
    {
        public string Text { get; set; }
        public int InvoiceId { get; set; }
    }
}
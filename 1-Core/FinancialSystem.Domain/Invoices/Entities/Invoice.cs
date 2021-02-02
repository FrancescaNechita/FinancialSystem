using FinancialSystem.Domain.Base;

namespace FinancialSystem.Domain.Invoices.Entities
{
    public class Invoice : BaseEntity
    {
        public string Identifier { get; set; }
        public decimal Amount { get; set; }
    }
}

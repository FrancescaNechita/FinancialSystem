namespace FinancialSystem.BusinessContracts.Invoices.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public decimal Amount { get; set; }
    }
}
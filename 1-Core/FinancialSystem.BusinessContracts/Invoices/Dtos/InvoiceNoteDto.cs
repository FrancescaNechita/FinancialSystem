namespace FinancialSystem.BusinessContracts.Invoices.Dtos
{
    public class 
        InvoiceNoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int InvoiceId { get; set; }
    }
}
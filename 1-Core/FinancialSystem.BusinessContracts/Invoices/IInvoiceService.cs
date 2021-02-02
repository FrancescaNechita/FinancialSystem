using FinancialSystem.BusinessContracts.Invoices.Dtos;

namespace FinancialSystem.BusinessContracts.Invoices
{
    public interface IInvoiceService
    {
        public InvoiceDto GetById(int id);
        public InvoiceDto Create(InvoiceDto invoice);
        public void Update(InvoiceDto invoice);
    }
}
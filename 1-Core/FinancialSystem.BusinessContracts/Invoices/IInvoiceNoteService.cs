using System.Collections.Generic;
using FinancialSystem.BusinessContracts.Invoices.Dtos;

namespace FinancialSystem.BusinessContracts.Invoices
{
    public interface IInvoiceNoteService
    {
        public IReadOnlyCollection<InvoiceNoteDto> GetAllByInvoiceId(int invoiceId);
        public InvoiceNoteDto GetById(int invoiceId, int id);
        public InvoiceNoteDto Create(InvoiceNoteDto invoiceNote);
        public void Update(InvoiceNoteDto invoiceNote);
    }
}
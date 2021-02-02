using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.Domain.Invoices.Entities;

namespace FinancialSystem.BusinessImplementations.Invoices.Mappings
{
    public static class InvoiceNoteDtoExtensions
    {
        public static InvoiceNote ToInvoiceNote(this InvoiceNoteDto invoiceNoteDto, int userId)
        {
            return invoiceNoteDto == null
                ? null
                : new InvoiceNote()
                {
                    Id = invoiceNoteDto.Id,
                    InvoiceId = invoiceNoteDto.InvoiceId,
                    Text = invoiceNoteDto.Text,
                    UserId = userId
                };
        }

        public static InvoiceNote ToInvoiceNote(this InvoiceNoteDto invoiceNoteDto, InvoiceNote invoiceNote)
        {
            invoiceNote.Text = invoiceNoteDto.Text;
            return invoiceNote;
        }
    }
}
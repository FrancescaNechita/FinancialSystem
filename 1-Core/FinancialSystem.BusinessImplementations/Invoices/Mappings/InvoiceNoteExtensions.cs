using System.Collections.Generic;
using System.Linq;
using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.Domain.Invoices.Entities;

namespace FinancialSystem.BusinessImplementations.Invoices.Mappings
{
    public static class InvoiceNoteExtensions
    {
        public static InvoiceNoteDto ToInvoiceNoteDto(this InvoiceNote invoiceNote)
        {
            return invoiceNote == null
                ? null
                : new InvoiceNoteDto()
                {
                    Id = invoiceNote.Id,
                    InvoiceId = invoiceNote.InvoiceId,
                    Text = invoiceNote.Text
                };
        }

        public static IReadOnlyCollection<InvoiceNoteDto> ToInvoiceNoteDtos(
            this IEnumerable<InvoiceNote> invoiceNotes)
        {
            return invoiceNotes.Select(x => x.ToInvoiceNoteDto()).ToList();
        }
    }
}

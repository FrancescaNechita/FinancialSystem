using System.Collections.Generic;
using System.Linq;
using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.Domain.Invoices.Entities;

namespace FinancialSystem.BusinessImplementations.Invoices.Mappings
{
    public static class InvoiceNoteDtoExtensions
    {
        public static InvoiceNote ToInvoiceNote(this InvoiceNoteDto invoiceNote)
        {
            return invoiceNote == null
                ? null
                : new InvoiceNote()
                {
                    Id = invoiceNote.Id,
                    InvoiceId = invoiceNote.InvoiceId,
                    Text = invoiceNote.Text
                };
        }

        public static IReadOnlyCollection<InvoiceNote> ToInvoiceNotes(
            this IEnumerable<InvoiceNoteDto> invoiceNoteDtos)
        {
            return invoiceNoteDtos.Select(x => x.ToInvoiceNote()).ToList();
        }
    }
}
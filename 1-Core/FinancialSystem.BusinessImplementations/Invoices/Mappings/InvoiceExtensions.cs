using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.Domain.Invoices.Entities;

namespace FinancialSystem.BusinessImplementations.Invoices.Mappings
{
    public static class InvoiceExtensions
    {
        public static InvoiceDto ToInvoiceDto(this Invoice invoice)
        {
            return invoice == null ? null : new InvoiceDto
            {
                Id = invoice.Id,
                Identifier = invoice.Identifier,
                Amount = invoice.Amount
            };
        }
    }
}
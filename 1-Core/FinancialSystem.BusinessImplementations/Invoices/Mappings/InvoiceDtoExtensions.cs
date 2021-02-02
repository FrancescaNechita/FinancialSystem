using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.Domain.Invoices.Entities;

namespace FinancialSystem.BusinessImplementations.Invoices.Mappings
{
    public static class InvoiceDtoExtensions
    {
        public static Invoice ToInvoice(this InvoiceDto invoiceDto, int userId)
        {
            return invoiceDto == null ? null : new Invoice
            {
                Id = invoiceDto.Id,
                Amount = invoiceDto.Amount,
                Identifier = invoiceDto.Identifier,
                UserId = userId
            };
        }

        public static Invoice ToInvoice(this InvoiceDto invoiceDto, Invoice invoice)
        {
            invoice.Amount = invoiceDto.Amount;
            invoice.Identifier = invoiceDto.Identifier;

            return invoice;
        }
    }
}
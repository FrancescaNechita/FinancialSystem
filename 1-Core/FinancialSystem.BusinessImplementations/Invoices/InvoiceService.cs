using FinancialSystem.BusinessContracts.Invoices;
using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.BusinessImplementations.Invoices.Mappings;
using FinancialSystem.Common.Exceptions;
using FinancialSystem.Domain.Invoices.Entities;
using FinancialSystem.Domain.Invoices.Repositories;

namespace FinancialSystem.BusinessImplementations.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public InvoiceDto GetById(int id)
        {
            var invoice = invoiceRepository.GetById(id)
                .ToInvoiceDto();
            if (invoice == null)
            {
                throw new NotFoundException();
            }

            return invoice;
        }

        public InvoiceDto Create(InvoiceDto invoice)
        {
            var insertedEntity = invoiceRepository.Insert(invoice.ToInvoice());
            invoiceRepository.Save();

            return insertedEntity.ToInvoiceDto();
        }

        public void Update(InvoiceDto invoice)
        {
            invoiceRepository.Update(invoice.ToInvoice());
            invoiceRepository.Save();
        }
    }
}
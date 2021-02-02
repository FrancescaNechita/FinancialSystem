using System.Security.Principal;
using FinancialSystem.BusinessContracts.Invoices;
using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.BusinessImplementations.Invoices.Mappings;
using FinancialSystem.Common.Exceptions;
using FinancialSystem.Domain.Invoices.Repositories;
using FinancialSystem.WebApi.Helpers;

namespace FinancialSystem.BusinessImplementations.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IPrincipal currentPrincipal;

        public InvoiceService(IInvoiceRepository invoiceRepository, IPrincipal currentPrincipal)
        {
            this.invoiceRepository = invoiceRepository;
            this.currentPrincipal = currentPrincipal;
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
            var insertedEntity = invoiceRepository.Insert(
                invoice.ToInvoice(currentPrincipal.GetUserId()));
            invoiceRepository.Save();

            return insertedEntity.ToInvoiceDto();
        }

        public void Update(InvoiceDto invoice)
        {
            var userId = currentPrincipal.GetUserId();
            var entity = invoiceRepository.GetById(invoice.Id);
            if (userId != entity?.UserId)
            {
                throw new ForbiddenException();
            }

            invoiceRepository.Update(invoice.ToInvoice(entity));
            invoiceRepository.Save();
        }
    }
}
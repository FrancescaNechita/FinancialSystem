using System.Collections.Generic;
using System.Security.Principal;
using FinancialSystem.BusinessContracts.Invoices;
using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.BusinessImplementations.Invoices.Mappings;
using FinancialSystem.Common.Exceptions;
using FinancialSystem.Domain.Invoices.Repositories;
using FinancialSystem.WebApi.Helpers;

namespace FinancialSystem.BusinessImplementations.Invoices
{
    public class InvoiceNoteService : IInvoiceNoteService
    {
        private readonly IInvoiceNoteRepository invoiceNoteRepository;
        private readonly IPrincipal currentPrincipal;

        public InvoiceNoteService(IInvoiceNoteRepository invoiceNoteRepository, IPrincipal currentPrincipal)
        {
            this.invoiceNoteRepository = invoiceNoteRepository;
            this.currentPrincipal = currentPrincipal;
        }
        public IReadOnlyCollection<InvoiceNoteDto> GetAllByInvoiceId(int invoiceId)
        {
            return invoiceNoteRepository.Filter(x => x.InvoiceId == invoiceId)
                .ToInvoiceNoteDtos();
        }

        public InvoiceNoteDto GetById(int invoiceId, int id)
        {
            var invoiceNote = invoiceNoteRepository.GetById(id);
            if (invoiceNote == null)
            {
                throw new NotFoundException();
            }

            if (invoiceNote.InvoiceId != invoiceId)
            {
                throw new BadRequestException();
            }

            return invoiceNote.ToInvoiceNoteDto();
        }

        public InvoiceNoteDto Create(InvoiceNoteDto invoiceNote)
        {
            var insertedEntity = invoiceNoteRepository.Insert(
                invoiceNote.ToInvoiceNote(currentPrincipal.GetUserId()));
            invoiceNoteRepository.Save();

            return insertedEntity.ToInvoiceNoteDto();
        }

        public void Update(InvoiceNoteDto invoiceNote)
        {
            var userId = currentPrincipal.GetUserId();
            var entity = invoiceNoteRepository.GetById(invoiceNote.Id);
            if (userId != entity?.UserId)
            {
                throw new ForbiddenException();
            }

            invoiceNoteRepository.Update(invoiceNote.ToInvoiceNote(entity));
            invoiceNoteRepository.Save();
        }
    }
}
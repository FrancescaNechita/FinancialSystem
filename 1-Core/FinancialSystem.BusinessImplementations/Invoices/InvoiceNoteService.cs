using System.Collections.Generic;
using FinancialSystem.BusinessContracts.Invoices;
using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.BusinessImplementations.Invoices.Mappings;
using FinancialSystem.Common.Exceptions;
using FinancialSystem.Domain.Invoices.Repositories;

namespace FinancialSystem.BusinessImplementations.Invoices
{
    public class InvoiceNoteService : IInvoiceNoteService
    {
        private readonly IInvoiceNoteRepository invoiceNoteRepository;

        public InvoiceNoteService(IInvoiceNoteRepository invoiceNoteRepository)
        {
            this.invoiceNoteRepository = invoiceNoteRepository;
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
            var insertedEntity = invoiceNoteRepository.Insert(invoiceNote.ToInvoiceNote());
            invoiceNoteRepository.Save();

            return insertedEntity.ToInvoiceNoteDto();
        }

        public void Update(InvoiceNoteDto invoiceNote)
        {
            invoiceNoteRepository.Update(invoiceNote.ToInvoiceNote());
            invoiceNoteRepository.Save();
        }
    }
}
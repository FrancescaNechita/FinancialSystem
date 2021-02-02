using FinancialSystem.BusinessContracts.Invoices;
using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialSystem.WebApi.Controllers
{
    [Route("api/invoices/{invoiceId}/notes")]
    [ApiController]
    public class InvoiceNoteController : ControllerBase
    {
        private readonly IInvoiceNoteService invoiceNoteService;

        public InvoiceNoteController(IInvoiceNoteService invoiceNoteService)
        {
            this.invoiceNoteService = invoiceNoteService;
        }

        [HttpGet]
        public IActionResult Get(int invoiceId)
        {
            return Ok(invoiceNoteService.GetAllByInvoiceId(invoiceId));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int invoiceId, int id)
        {
            return Ok(invoiceNoteService.GetById(invoiceId, id));
        }

        [HttpPost]
        public IActionResult Post(int invoiceId, InvoiceNoteDto invoiceNote)
        {
            if (invoiceId != invoiceNote?.InvoiceId)
            {
                throw new BadRequestException(ExceptionMessageKeys.BadRequest);
            }

            var createdInvoiceNote = invoiceNoteService.Create(invoiceNote);
            return Created(createdInvoiceNote.Id.ToString(), createdInvoiceNote);
        }

        [HttpPut]
        public IActionResult Put(int invoiceId, InvoiceNoteDto invoiceNote)
        {
            if (invoiceId != invoiceNote?.InvoiceId)
            {
                throw new BadRequestException(ExceptionMessageKeys.BadRequest);
            }

            invoiceNoteService.Update(invoiceNote);
            return NoContent();
        }
    }
}

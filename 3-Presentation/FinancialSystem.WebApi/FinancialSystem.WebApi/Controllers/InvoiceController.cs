using FinancialSystem.BusinessContracts.Invoices;
using FinancialSystem.BusinessContracts.Invoices.Dtos;
using FinancialSystem.WebApi.ApiKey;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialSystem.WebApi.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = Policies.AllUsers)]
        public IActionResult Get(int id)
        {
            return Ok(invoiceService.GetById(id));
        }

        [HttpPost]
        [Authorize(Policy = Policies.OnlyAdmins)]
        public IActionResult Post(InvoiceDto invoice)
        {
            var createdInvoiced = invoiceService.Create(invoice);
            return Created(createdInvoiced.Id.ToString(), createdInvoiced);
        }

        [HttpPut]
        [Authorize(Policy = Policies.OnlyAdmins)]
        public IActionResult Put(InvoiceDto invoice)
        {
            invoiceService.Update(invoice);
            return NoContent();
        }
    }
}

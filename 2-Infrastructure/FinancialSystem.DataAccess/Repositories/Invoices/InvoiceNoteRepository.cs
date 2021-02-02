using FinancialSystem.DataAccess.Context;
using FinancialSystem.DataAccess.Repositories.Base;
using FinancialSystem.Domain.Invoices.Entities;
using FinancialSystem.Domain.Invoices.Repositories;

namespace FinancialSystem.DataAccess.Repositories.Invoices
{
    public class InvoiceNoteRepository : BaseRepository<InvoiceNote>, IInvoiceNoteRepository
    {
        public InvoiceNoteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
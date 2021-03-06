﻿using FinancialSystem.Domain.Base;
using FinancialSystem.Domain.Invoices.Entities;

namespace FinancialSystem.Domain.Invoices.Repositories
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
    }
}
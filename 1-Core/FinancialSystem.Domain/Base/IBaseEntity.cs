using System;

namespace FinancialSystem.Domain.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        int UserId { get; set; }
    }
}
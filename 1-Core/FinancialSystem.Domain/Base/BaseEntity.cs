using System;

namespace FinancialSystem.Domain.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
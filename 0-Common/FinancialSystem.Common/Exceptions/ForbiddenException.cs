using System;

namespace FinancialSystem.Common.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base(ExceptionMessageKeys.Forbidden) { }

        public ForbiddenException(string message)
            : base(message) { }

        public ForbiddenException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
using System;

namespace FinancialSystem.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base(ExceptionMessageKeys.BadRequest) { }

        public BadRequestException(string message) :
            base(message)  { }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
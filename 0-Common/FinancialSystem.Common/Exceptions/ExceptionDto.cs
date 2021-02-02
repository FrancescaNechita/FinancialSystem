namespace FinancialSystem.Common.Exceptions
{
    public class ExceptionDto
    {
        public string Message { get; set; }

        public ExceptionDto() { }

        public ExceptionDto(string message)
        {
            Message = message;
        }
    }
}
namespace MyCarService.ErrorHandling
{
    public class Error
    {
        public Error(ErrorCode errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        public ErrorCode ErrorCode { get; }
        public string ErrorMessage { get; }
    }
}

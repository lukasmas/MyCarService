namespace MyCarService.ErrorHandling
{
    public class Error
    {
        public Error(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; }
    }
}

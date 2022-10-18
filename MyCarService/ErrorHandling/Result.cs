namespace MyCarService.ErrorHandling
{
    public interface IResult<TSuccess, TError> {
        public bool IsSuccess();
        public bool IsFail();

        public TError? GetError();
        public TSuccess? GetSuccess();
    }

    public class Result<TSuccess, TError> : IResult<TSuccess, TError>
    {
        public Result(TSuccess success) => _success = success;
        public Result(TError error) => _error = error;

        private readonly TSuccess? _success;
        private readonly TError? _error;

        public bool IsFail() => !IsSuccess();

        public bool IsSuccess() => _success != null;

        public TError? GetError() => _error;

        public TSuccess? GetSuccess() => _success;  
    }
}
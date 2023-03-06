namespace LibraryServer.Extensions
{
    public class ServiceMethodContentResult<TResult> : ServiceContentResult
    {
        public TResult? Result { get; init; }
        public ServiceMethodContentResult(bool isSuccess, StatusCode statusCode) : base(isSuccess, statusCode) { }

        public ServiceMethodContentResult(TResult? result) : base(true, StatusCode.Success)
        {
            Result = result;
        }

        public ServiceMethodContentResult(bool isSuccess, StatusCode statusCode, TResult? result) : base(isSuccess, statusCode)
        {
            Result = result;
        }
    }
}

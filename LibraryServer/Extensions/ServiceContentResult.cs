namespace LibraryServer.Extensions
{
    public class ServiceContentResult
    {
        public bool IsSuccess { get; set; }
        public StatusCode StatusCode { get; set; }
        public ServiceContentResult(bool isSuccess, StatusCode statusCode)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
        }
    }
}

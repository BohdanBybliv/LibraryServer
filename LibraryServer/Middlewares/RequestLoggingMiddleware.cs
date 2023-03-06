namespace LibraryServer.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                var bodyAsText = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();
                _logger.LogInformation(
                    "Request:\nMethod: {method}\nURL: {url}\nHeaders: {headers}\nQuery params: {query}\nBody: {body}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Request?.Headers,
                    context.Request?.QueryString,
                    bodyAsText);
            }
        }
    }
}

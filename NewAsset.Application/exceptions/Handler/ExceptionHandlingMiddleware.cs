
namespace NewAsset.Application.exceptions.Handler
{

    /// <summary>
    /// Global exception handling middleware configuration
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    ValidationException => StatusCodes.Status400BadRequest,
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

                var response = new ProblemDetails
                {
                    Title = ex.GetType().Name,
                    Detail = ex.Message,
                    Status = context.Response.StatusCode,
                    Instance = context.Request.Path
                };

                if (ex is ValidationException validationException)
                {
                    response.Extensions.Add("ValidationErrors", validationException.Errors);
                }
                response.Extensions.Add("traceId", context.TraceIdentifier);
                response.Extensions.Add("success", false);
                response.Extensions.Add("HasError", true);
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }

}

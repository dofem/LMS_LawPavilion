using LIBRARY_MANAGEMENT_SYSTEM.Utilities;

namespace LIBRARY_MANAGEMENT_SYSTEM.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next,ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError($"An Error occured: {ex.Message}");
                await context.Response.WriteAsJsonAsync(
                    ApiResponse<object>.Fail(ApiResponseMessages.ErrorMessage, ApiResponseMessages.ErrorCode)
                );
            }
        }
    }
}

using LIBRARY_MANAGEMENT_SYSTEM.Middleware;

public static class MiddlewareExtensions
{
    public static void UseGlobalMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}

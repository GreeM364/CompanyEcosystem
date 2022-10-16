using CompanyEcosystem.BL.Infrastructure;

namespace CompanyEcosystem.PL.Middlewares;

public class ExceptionHandlingMiddleware {

    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger logger) {
        try
        {
            await _next(context);
        }
        catch (ValidationException exception)
        {
            logger.LogError(exception, "An validation exception was thrown as a result of the request");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.Redirect("/Error/Error400");
        }
        catch (Exception exception) {
            HandleException(context, exception, logger);
        }
    }

    private void HandleException(HttpContext context, Exception exception, ILogger logger) {

        logger.LogError(exception, "An exception was thrown as a result of the request");
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.Redirect("/Error/Error500");
    }
}
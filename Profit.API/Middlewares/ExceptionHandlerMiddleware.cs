namespace Profit.API.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (InvalidOperationException ex)
        {
            await Handle(context, ex);
        }
        catch (EntityNotFoundException ex)
        {
            await Handle(context, ex);
        }
        catch (OperationCanceledException ex)
        {
            await Handle(context, ex);
        }
        catch (ValidationException ex)
        {
            await Handle(context, ex);
        }
        catch (Exception ex)
        {
            await Handle(context, ex);
        }
    }
    private static async Task Handle(HttpContext context, InvalidOperationException ex)
    {
        context.Response.StatusCode = 400;
        context.Response.ContentType = "application/json";

        var errorMessage = JsonSerializer.Serialize(
            new
            {
                Messages = ex.Message,
                context.Response.StatusCode
            });

        await context.Response.WriteAsync(errorMessage);
    }
    private static async Task Handle(HttpContext context, EntityNotFoundException ex)
    {
        context.Response.StatusCode = 404;
        context.Response.ContentType = "application/json";

        var errorMessage = JsonSerializer.Serialize(
            new
            {
                Messages = ex.Message,
                context.Response.StatusCode
            });

        await context.Response.WriteAsync(errorMessage);
    }
    private static async Task Handle(HttpContext context, OperationCanceledException _)
    {
        context.Response.StatusCode = 499;
        context.Response.ContentType = "application/json";

        var errorMessage = JsonSerializer.Serialize(
            new
            {
                Messages = "Operation canceled",
                context.Response.StatusCode
            });

        await context.Response.WriteAsync(errorMessage);
    }
    private static async Task Handle(HttpContext context, ValidationException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var errorMessage = JsonSerializer.Serialize(
            new
            {
                Messages = ex.Message.Split("\n"),
                context.Response.StatusCode
            });

        await context.Response.WriteAsync(errorMessage);
    }

    private static async Task Handle(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var errorMessage = JsonSerializer.Serialize(
            new
            {
                Messages = ex.Message.Split("\n"),
                context.Response.StatusCode
            });

        await context.Response.WriteAsync(errorMessage);
    }
}

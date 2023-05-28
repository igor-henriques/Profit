namespace Profit.API.Middlewares;

public sealed class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
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
        catch (ArgumentNullException ex)
        {
            await Handle(context, ex);
        }
        catch (ArgumentException ex)
        {
            await Handle(context, ex);
        }
        catch (InvalidTenantException ex)
        {
            await Handle(context, ex);
        }
        catch (InvalidCredentialsException ex)
        {
            await Handle(context, ex);
        }
        catch (InvalidMeasurementConversionException ex)
        {
            await Handle(context, ex);
        }
        catch (InvalidEntityDeleteException ex)
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
    private static async Task Handle(HttpContext context, InvalidTenantException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        context.Response.ContentType = "application/json";

        var errorMessage = JsonSerializer.Serialize(
            new
            {
                Messages = ex.Message,
                context.Response.StatusCode
            });

        await context.Response.WriteAsync(errorMessage);
    }

    private static async Task Handle(HttpContext context, ArgumentException ex)
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

    private static async Task Handle(HttpContext context, ArgumentNullException ex)
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

    private static async Task Handle(HttpContext context, InvalidCredentialsException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        context.Response.ContentType = "application/json";

        var errorMessage = JsonSerializer.Serialize(
            new
            {
                Messages = ex.Message.Split("\n"),
                context.Response.StatusCode
            });

        await context.Response.WriteAsync(errorMessage);
    }

    private static async Task Handle(HttpContext context, InvalidMeasurementConversionException ex)
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

    private static async Task Handle(HttpContext context, InvalidEntityDeleteException ex)
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
}

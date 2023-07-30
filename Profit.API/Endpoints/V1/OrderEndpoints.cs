namespace Profit.API.Endpoints.V1;

public static class OrderEndpoints
{
    public static void ConfigureOrderEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.Order.GetPaginated, async (
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(new GetPaginatedOrdersQuery(pageNumber, pageSize), cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.ORDER).RequireAuthorization();

        app.MapGet(Routes.Order.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueOrderQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.ORDER).RequireAuthorization();

        app.MapPost(Routes.Order.Create, async (
            [FromBody] CreateOrderCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.ORDER).RequireAuthorization();

        app.MapPut(Routes.Order.Put, async (
            [FromBody] PutOrderCommand putOrderCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(putOrderCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.ORDER).RequireAuthorization();

        app.MapDelete(Routes.Order.Delete, async (
            [FromBody] DeleteOrderCommand deleteOrderCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteOrderCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.ORDER).RequireAuthorization();
    }
}

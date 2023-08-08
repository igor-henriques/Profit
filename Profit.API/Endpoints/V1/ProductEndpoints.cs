namespace Profit.API.Endpoints.V1;

public static class ProductEndpoints
{
    public static void ConfigureProductEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.Product.GetPaginated, async (
            [FromQuery] int pageNumber,
            [FromQuery] int itemsPerPage,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(new GetPaginatedProductsQuery(pageNumber, itemsPerPage), cancellationToken);

            return Results.Ok(response);
        }).WithTags(SwaggerTags.PRODUCT).RequireAuthorization();

        app.MapGet(Routes.Product.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueProductQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.PRODUCT).RequireAuthorization();

        app.MapPost(Routes.Product.Create, async (
            [FromBody] CreateProductCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.PRODUCT).RequireAuthorization();

        app.MapPost(Routes.Product.BulkCreate, async (
            [FromBody] CreateManyProductsCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.PRODUCT).RequireAuthorization();

        app.MapPut(Routes.Product.Put, async (
            [FromBody] PutProductCommand putProductCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(putProductCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.PRODUCT).RequireAuthorization();

        app.MapDelete(Routes.Product.Delete, async (
            [FromBody] DeleteProductCommand deleteProductCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteProductCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.PRODUCT).RequireAuthorization();
    }
}

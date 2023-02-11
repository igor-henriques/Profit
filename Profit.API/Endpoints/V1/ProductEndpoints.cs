namespace Profit.API.Endpoints.V1;

public static class ProductEndpoints
{
    public static void ConfigureProductEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.Product.GetMany, async (
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetManyProductsQuery();
            var response = await mediator.Send(query, cancellationToken);

            return response.Any() ? Results.Ok(response) : Results.NoContent();
        }).WithTags(SwaggerTags.PRODUCT);

        app.MapGet(Routes.Product.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueProductQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.PRODUCT);

        app.MapPost(Routes.Product.Create, async (
            [FromBody] CreateProductCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.PRODUCT);

        app.MapPost(Routes.Product.BulkCreate, async (
            [FromBody] CreateManyProductsCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return response.Any() ? Results.Ok(response) : Results.NoContent();
        }).WithTags(SwaggerTags.PRODUCT);

        app.MapPatch(Routes.Product.Patch, async (
            [FromBody] PatchProductCommand patchProductCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(patchProductCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.PRODUCT);

        app.MapPut(Routes.Product.Put, async (
            [FromBody] PutProductCommand putProductCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(putProductCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.PRODUCT);

        app.MapDelete(Routes.Product.Delete, async (
            [FromBody] DeleteProductCommand deleteProductCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteProductCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.PRODUCT);
    }
}

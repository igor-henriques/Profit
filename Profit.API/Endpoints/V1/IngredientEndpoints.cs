namespace Profit.API.Endpoints.V1;

public static class IngredientEndpoints
{
    public static void ConfigureIngredientEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.Ingredient.GetMany, async (
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetManyIngredientsQuery();
            var response = await mediator.Send(query, cancellationToken);

            return Results.Ok(response);
        }).WithTags(SwaggerTags.INGREDIENT).RequireAuthorization();

        app.MapGet(Routes.Ingredient.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueIngredientQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.INGREDIENT).RequireAuthorization();

        app.MapPost(Routes.Ingredient.Create, async (
            [FromBody] CreateIngredientCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.INGREDIENT).RequireAuthorization();

        app.MapPost(Routes.Ingredient.BulkCreate, async (
            [FromBody] CreateManyIngredientsCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.INGREDIENT).RequireAuthorization();

        app.MapPatch(Routes.Ingredient.Patch, async (
            [FromBody] PatchIngredientCommand patchIngredientCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(patchIngredientCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.INGREDIENT).RequireAuthorization();

        app.MapPut(Routes.Ingredient.Put, async (
            [FromBody] PutIngredientCommand putIngredientCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(putIngredientCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.INGREDIENT).RequireAuthorization();

        app.MapDelete(Routes.Ingredient.Delete, async (
            [FromBody] DeleteIngredientCommand deleteIngredientCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteIngredientCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.INGREDIENT).RequireAuthorization();
    }
}

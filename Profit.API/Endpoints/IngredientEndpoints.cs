using Profit.Domain.Commands.Ingredient.CreateMany;
using Profit.Domain.Commands.Ingredient.Patch;

namespace Profit.API.Endpoints;

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

            return response.Any() ? Results.Ok(response) : Results.NoContent();
        });

        app.MapGet(Routes.Ingredient.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueIngredientQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        });

        app.MapPost(Routes.Ingredient.Create, async (
            [FromBody] CreateIngredientCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        });

        app.MapPost(Routes.Ingredient.BulkCreate, async (
            [FromBody] CreateManyIngredientsCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return response.Any() ? Results.Ok(response) : Results.NoContent();
        });

        app.MapPatch(Routes.Ingredient.Patch, async (
            [FromBody] PatchIngredientCommand patchIngredientCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(patchIngredientCommand);
            return Results.NoContent();
        });

        app.MapPut(Routes.Ingredient.Put, () =>
        {
            return Results.Ok();
        });

        app.MapDelete(Routes.Ingredient.Delete, () =>
        {
            return Results.Ok();
        });
    }
}

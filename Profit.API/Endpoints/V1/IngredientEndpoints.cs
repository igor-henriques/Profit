﻿namespace Profit.API.Endpoints.V1;

public static class IngredientEndpoints
{
    public static void ConfigureIngredientEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.Ingredient.GetPaginated, GetPaginated)
            .WithTags(SwaggerTags.INGREDIENT)
            .RequireAuthorization();

        static async Task<IResult> GetPaginated(
            [FromQuery] int pageNumber, 
            [FromQuery] int itemsPerPage, 
            [FromServices] IMediator mediator, 
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(new GetPaginatedIngredientsQuery(pageNumber, itemsPerPage), cancellationToken);
            return Results.Ok(response);
        }

        app.MapGet(Routes.Ingredient.GetUnique, GetUnique)
            .WithTags(SwaggerTags.INGREDIENT)
            .RequireAuthorization();

       static async Task<IResult> GetUnique(
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            var query = new GetUniqueIngredientQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }

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

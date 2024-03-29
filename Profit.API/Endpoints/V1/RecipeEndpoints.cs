﻿namespace Profit.API.Endpoints.V1;

public static class RecipeEndpoints
{
    public static void ConfigureRecipeEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.Recipe.GetPaginated, async (
            [FromQuery] int pageNumber,
            [FromQuery] int itemsPerPage,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(new GetPaginatedRecipesQuery(pageNumber, itemsPerPage), cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.RECIPE).RequireAuthorization();

        app.MapGet(Routes.Recipe.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueRecipeQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.RECIPE).RequireAuthorization();

        app.MapPost(Routes.Recipe.Create, async (
            [FromBody] CreateRecipeCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.RECIPE).RequireAuthorization();

        app.MapPost(Routes.Recipe.BulkCreate, async (
            [FromBody] CreateManyRecipesCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.RECIPE).RequireAuthorization();

        app.MapPut(Routes.Recipe.Put, async (
            [FromBody] PutRecipeCommand putRecipeCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(putRecipeCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.RECIPE).RequireAuthorization();

        app.MapDelete(Routes.Recipe.Delete, async (
            [FromBody] DeleteRecipeCommand deleteRecipeCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteRecipeCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.RECIPE).RequireAuthorization();
    }
}

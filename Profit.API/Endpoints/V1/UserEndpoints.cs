namespace Profit.API.Endpoints.V1;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.User.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueIngredientQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }).WithTags(USER_SWAGGER_TAG);

        app.MapPost(Routes.User.Create, async (
            [FromBody] CreateUserCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(USER_SWAGGER_TAG);

        app.MapPut(Routes.User.Put, async (
            [FromBody] PutIngredientCommand putIngredientCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(putIngredientCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(USER_SWAGGER_TAG);

        app.MapDelete(Routes.User.Delete, async (
            [FromBody] DeleteIngredientCommand deleteIngredientCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteIngredientCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(USER_SWAGGER_TAG);

        app.MapPost(Routes.User.Authenticate, async (
            [FromBody] DeleteIngredientCommand deleteIngredientCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteIngredientCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(USER_SWAGGER_TAG);
    }
}

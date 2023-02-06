namespace Profit.API.Endpoints.V1;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.User.GetMany, async (
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetManyUsersQuery();
            var response = await mediator.Send(query, cancellationToken);

            return response.Any() ? Results.Ok(response) : Results.NoContent();
        }).WithTags(SwaggerTags.USER);

        app.MapGet(Routes.User.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueUserQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.USER);

        app.MapPost(Routes.User.Create, async (
            [FromBody] CreateUserCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.CreatedAtRoute(Routes.User.GetUnique, new { guid = response }, response);
        }).WithTags(SwaggerTags.USER);

        app.MapPost(Routes.User.BulkCreate, async (
            [FromBody] CreateManyUsersCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return response.Any() ? Results.Ok(response) : Results.NoContent();
        }).WithTags(SwaggerTags.USER);

        app.MapPatch(Routes.User.Patch, async (
            [FromBody] PatchUserCommand patchUserCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(patchUserCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.USER);

        app.MapPut(Routes.User.Put, async (
            [FromBody] PutUserCommand putUserCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(putUserCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.USER);

        app.MapDelete(Routes.User.Delete, async (
            [FromBody] DeleteUserCommand deleteUserCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteUserCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.USER);
    }
}

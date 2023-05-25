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

            return Results.Ok(response);
        }).WithTags(SwaggerTags.USER).RequireAuthorization();

        app.MapGet(Routes.User.GetUnique, async (
            [FromQuery] Guid guid,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUniqueUserQuery(guid);
            var response = await mediator.Send(query, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.USER).RequireAuthorization();

        app.MapPost(Routes.User.Create, async (
            [FromBody] CreateUserCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.USER);

        app.MapPatch(Routes.User.Patch, async (
            [FromBody] PatchUserCommand patchUserCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(patchUserCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.USER).RequireAuthorization();

        app.MapPut(Routes.User.Put, async (
            [FromBody] PutUserCommand putUserCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(putUserCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.USER).RequireAuthorization();

        app.MapDelete(Routes.User.Delete, async (
            [FromBody] DeleteUserCommand deleteUserCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(deleteUserCommand, cancellationToken);
            return Results.NoContent();
        }).WithTags(SwaggerTags.USER).RequireAuthorization();

        app.MapPost(Routes.User.Authenticate, async (
            [FromBody] AuthenticateUserCommand authenticateUserCommand,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(authenticateUserCommand, cancellationToken);
            return Results.Ok(response);
        }).WithTags(SwaggerTags.USER);
    }
}

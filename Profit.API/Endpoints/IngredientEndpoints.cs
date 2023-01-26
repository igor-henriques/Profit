namespace Profit.API.Endpoints;

public static class IngredientEndpoints
{
    public static void ConfigureIngredientEndpoints(this WebApplication app)
    {
        app.MapGet(Routes.Ingredient.GetMany, () =>
        {
            return Results.Ok();
        });

        app.MapGet(Routes.Ingredient.GetUnique, () =>
        {
            return Results.Ok();
        });

        app.MapPost(Routes.Ingredient.Create, () =>
        {
            return Results.Ok();
        });

        app.MapPost(Routes.Ingredient.BulkCreate, () =>
        {
            return Results.Ok();
        });

        app.MapPatch(Routes.Ingredient.UpdatePartially, () =>
        {
            return Results.Ok();
        });

        app.MapPut(Routes.Ingredient.UpdateAll, () =>
        {
            return Results.Ok();
        });

        app.MapDelete(Routes.Ingredient.Delete, () =>
        {
            return Results.Ok();
        });
    }
}

namespace Profit.DependencyInjection.Injectors;

public static class ConfigureCommandBatchProcessor
{
    public static IServiceCollection AddCommandBatchProcessors(this IServiceCollection services)
    {
        services.AddSingleton<ICommandBatchProcessorService<CreateIngredientCommand>, CommandBatchProcessorService<CreateIngredientCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<DeleteIngredientCommand>, CommandBatchProcessorService<DeleteIngredientCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<PatchIngredientCommand>, CommandBatchProcessorService<PatchIngredientCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<PutIngredientCommand>, CommandBatchProcessorService<PutIngredientCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<CreateManyIngredientsCommand>, CommandBatchProcessorService<CreateManyIngredientsCommand>>();

        services.AddSingleton<ICommandBatchProcessorService<CreateProductCommand>, CommandBatchProcessorService<CreateProductCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<DeleteProductCommand>, CommandBatchProcessorService<DeleteProductCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<PatchProductCommand>, CommandBatchProcessorService<PatchProductCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<PutProductCommand>, CommandBatchProcessorService<PutProductCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<CreateManyProductsCommand>, CommandBatchProcessorService<CreateManyProductsCommand>>();

        services.AddSingleton<ICommandBatchProcessorService<CreateRecipeCommand>, CommandBatchProcessorService<CreateRecipeCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<DeleteRecipeCommand>, CommandBatchProcessorService<DeleteRecipeCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<PatchRecipeCommand>, CommandBatchProcessorService<PatchRecipeCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<PutRecipeCommand>, CommandBatchProcessorService<PutRecipeCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<CreateManyRecipesCommand>, CommandBatchProcessorService<CreateManyRecipesCommand>>();

        services.AddSingleton<ICommandBatchProcessorService<CreateUserCommand>, CommandBatchProcessorService<CreateUserCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<DeleteUserCommand>, CommandBatchProcessorService<DeleteUserCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<PatchUserCommand>, CommandBatchProcessorService<PatchUserCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<PutUserCommand>, CommandBatchProcessorService<PutUserCommand>>();
        services.AddSingleton<ICommandBatchProcessorService<CreateManyUsersCommand>, CommandBatchProcessorService<CreateManyUsersCommand>>();

        return services;
    }
}

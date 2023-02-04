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

        services.AddSingleton<ICommandBatchProcessorService<CreateUserCommand>, CommandBatchProcessorService<CreateUserCommand>>();

        return services;
    }
}

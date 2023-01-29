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
        services.AddSingleton<ICommandBatchProcessorService<CreateUserCommand>, CommandBatchProcessorService<CreateUserCommand>>();

        return services;
    }
}

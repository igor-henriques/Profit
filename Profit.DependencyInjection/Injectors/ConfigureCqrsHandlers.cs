namespace Profit.DependencyInjection.Injectors;

public static class ConfigureCqrsHandlers
{
    public static IServiceCollection AddCqrsHandlers(this IServiceCollection services)
    {
        services.AddMediatR(
            typeof(CreateIngredientCommandHandler).Assembly,
            typeof(DeleteIngredientCommandHandler).Assembly,
            typeof(PatchIngredientCommandHandler).Assembly,
            typeof(PutIngredientCommandHandler).Assembly,
            typeof(GetManyIngredientsQueryHandler).Assembly,
            typeof(GetUniqueIngredientQueryHandler).Assembly,
            typeof(CreateProductCommandHandler).Assembly,
            typeof(DeleteProductCommandHandler).Assembly,
            typeof(PatchProductCommandHandler).Assembly,
            typeof(PutProductCommandHandler).Assembly,
            typeof(GetManyProductsQueryHandler).Assembly,
            typeof(GetUniqueProductQueryHandler).Assembly,
            typeof(CreateUserCommandHandler).Assembly);

        return services;
    }
}
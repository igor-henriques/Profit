namespace Profit.DependencyInjection.Injectors;

public static class ConfigureCqrsHandlers
{
    public static IServiceCollection AddCqrsHandlers(this IServiceCollection services)
    {
        services.AddMediatR(
            typeof(CreateIngredientCommandHandler).Assembly,
            typeof(GetManyIngredientsQueryHandler).Assembly,
            typeof(GetUniqueIngredientQueryHandler).Assembly);

        return services;
    }
}
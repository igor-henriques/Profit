namespace Profit.DependencyInjection.Injectors;

public static class ConfigureValidators
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<Ingredient>, IngredientValidator>();
        services.AddSingleton<IValidator<IngredientDTO>, IngredientDtoValidator>();
        return services;
    }
}

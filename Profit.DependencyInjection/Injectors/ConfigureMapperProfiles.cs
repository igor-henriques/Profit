namespace Profit.DependencyInjection.Injectors;

public static class ConfigureMapperProfiles
{
    public static IServiceCollection AddMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IngredientProfile));
        return services;
    }
}

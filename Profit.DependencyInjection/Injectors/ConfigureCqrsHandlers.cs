using Profit.Application.Commands.Ingredient.Create;

namespace Profit.DependencyInjection.Injectors;

public static class ConfigureCqrsHandlers
{
    public static IServiceCollection AddCqrsHandlers(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
            typeof(CreateIngredientCommandHandler).Assembly)
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)));

        return services;
    }
}
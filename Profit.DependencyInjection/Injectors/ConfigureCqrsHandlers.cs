namespace Profit.DependencyInjection.Injectors;

public static class ConfigureCqrsHandlers
{
    public static IServiceCollection AddCqrsHandlers(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
            typeof(CreateIngredientCommandHandler).Assembly,
            typeof(CreateManyIngredientsCommandHandler).Assembly,
            typeof(DeleteIngredientCommandHandler).Assembly,
            typeof(PutIngredientCommandHandler).Assembly,
            typeof(GetManyIngredientsQueryHandler).Assembly,
            typeof(GetUniqueIngredientQueryHandler).Assembly,
            typeof(CreateRecipeCommandHandler).Assembly,
            typeof(CreateManyRecipesCommandHandler).Assembly,
            typeof(DeleteRecipeCommandHandler).Assembly,
            typeof(PutRecipeCommandHandler).Assembly,
            typeof(GetManyRecipesQueryHandler).Assembly,
            typeof(GetUniqueRecipeQueryHandler).Assembly,
            typeof(CreateProductCommandHandler).Assembly,
            typeof(CreateManyProductsCommandHandler).Assembly,
            typeof(DeleteProductCommandHandler).Assembly,
            typeof(PutProductCommandHandler).Assembly,
            typeof(GetManyProductsQueryHandler).Assembly,
            typeof(GetUniqueProductQueryHandler).Assembly,
            typeof(CreateUserCommandHandler).Assembly,
            typeof(DeleteUserCommandHandler).Assembly,
            typeof(PutUserCommandHandler).Assembly,
            typeof(GetManyUsersQueryHandler).Assembly,
            typeof(GetUniqueUserQueryHandler).Assembly)
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)));

        return services;
    }
}
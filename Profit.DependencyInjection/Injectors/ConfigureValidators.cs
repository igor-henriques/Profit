namespace Profit.DependencyInjection.Injectors;

public static class ConfigureValidators
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<Ingredient>, IngredientValidator>();
        services.AddSingleton<IValidator<IngredientDto>, IngredientDtoValidator>();
        services.AddSingleton<IValidator<CreateIngredientCommand>, CreateIngredientCommandValidator>();

        services.AddSingleton<IValidator<Product>, ProductValidator>();
        services.AddSingleton<IValidator<ProductDto>, ProductDtoValidator>();
        services.AddSingleton<IValidator<CreateProductCommand>, CreateProductCommandValidator>();

        services.AddSingleton<IValidator<Recipe>, RecipeValidator>();
        services.AddSingleton<IValidator<RecipeDto>, RecipeDtoValidator>();
        services.AddSingleton<IValidator<CreateRecipeCommand>, CreateRecipeCommandValidator>();

        services.AddSingleton<IValidator<User>, UserValidator>();
        services.AddSingleton<IValidator<UserDto>, UserDtoValidator>();
        services.AddSingleton<IValidator<CreateUserCommand>, CreateUserCommandValidator>();

        return services;
    }
}

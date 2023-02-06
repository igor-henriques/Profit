namespace Profit.DependencyInjection.Injectors;

public static class ConfigureValidators
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<Ingredient>, IngredientValidator>();
        services.AddSingleton<IValidator<IngredientDTO>, IngredientDtoValidator>();
        services.AddSingleton<IValidator<CreateIngredientDTO>, CreateIngredientDtoValidator>();

        services.AddSingleton<IValidator<Product>, ProductValidator>();
        services.AddSingleton<IValidator<ProductDTO>, ProductDtoValidator>();
        services.AddSingleton<IValidator<CreateProductDTO>, CreateProductDtoValidator>();

        services.AddSingleton<IValidator<Recipe>, RecipeValidator>();
        services.AddSingleton<IValidator<RecipeDTO>, RecipeDtoValidator>();
        services.AddSingleton<IValidator<CreateRecipeDTO>, CreateRecipeDtoValidator>();

        services.AddSingleton<IValidator<User>, UserValidator>();
        services.AddSingleton<IValidator<UserDTO>, UserDtoValidator>();
        services.AddSingleton<IValidator<CreateUserDTO>, CreateUserDtoValidator>();

        return services;
    }
}

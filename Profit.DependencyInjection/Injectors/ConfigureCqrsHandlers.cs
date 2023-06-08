using Profit.Domain.Commands.Order.Create;
using Profit.Domain.Commands.Order.Delete;
using Profit.Domain.Commands.Order.Put;
using Profit.Domain.Queries.Order.GetPaginated;
using Profit.Domain.Queries.Order.GetUnique;

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
            typeof(GetPaginatedIngredientsQueryHandler).Assembly,
            typeof(GetUniqueIngredientQueryHandler).Assembly,
            typeof(CreateRecipeCommandHandler).Assembly,
            typeof(CreateManyRecipesCommandHandler).Assembly,
            typeof(DeleteRecipeCommandHandler).Assembly,
            typeof(PutRecipeCommandHandler).Assembly,
            typeof(GetPaginatedRecipesQueryHandler).Assembly,
            typeof(GetUniqueRecipeQueryHandler).Assembly,
            typeof(CreateProductCommandHandler).Assembly,
            typeof(CreateManyProductsCommandHandler).Assembly,
            typeof(DeleteProductCommandHandler).Assembly,
            typeof(PutProductCommandHandler).Assembly,
            typeof(GetPaginatedProductsQueryHandler).Assembly,
            typeof(GetUniqueProductQueryHandler).Assembly,
            typeof(CreateUserCommandHandler).Assembly,
            typeof(DeleteUserCommandHandler).Assembly,
            typeof(PutUserCommandHandler).Assembly,
            typeof(GetPaginatedUsersQueryHandler).Assembly,
            typeof(GetUniqueUserQueryHandler).Assembly,
            typeof(CreateOrderCommandHandler).Assembly,
            typeof(DeleteOrderCommand).Assembly,
            typeof(PutOrderCommand).Assembly,
            typeof(GetPaginatedOrdersQueryHandler).Assembly,
            typeof(GetUniqueOrderQueryHandler).Assembly)
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)));

        return services;
    }
}
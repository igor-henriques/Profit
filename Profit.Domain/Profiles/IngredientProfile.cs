namespace Profit.Domain.Profiles;

public sealed class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        CreateMap<IngredientDto, Ingredient>().ReverseMap();
        CreateMap<CreateIngredientCommand, Ingredient>();
        CreateMap<PutIngredientCommand, Ingredient>();
    }
}

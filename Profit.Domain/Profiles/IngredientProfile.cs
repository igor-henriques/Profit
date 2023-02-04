namespace Profit.Domain.Profiles;

public sealed class IngredientProfile : Profile
{
	public IngredientProfile()
	{
		CreateMap<IngredientDTO, Ingredient>().ReverseMap();
		CreateMap<CreateIngredientDTO, Ingredient>();
	}
}

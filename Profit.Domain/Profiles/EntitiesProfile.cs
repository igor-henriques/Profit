namespace Profit.Domain.Profiles;

public sealed class EntitiesProfile : Profile
{
	public EntitiesProfile()
	{
		CreateMap<IngredientDTO, Ingredient>().ReverseMap();
	}
}

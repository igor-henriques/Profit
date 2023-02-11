namespace Profit.Domain.Profiles;

public sealed class IngredientProfile : Profile
{
	public IngredientProfile()
	{
		CreateMap<IngredientDTO, Ingredient>().ReverseMap();
		CreateMap<CreateIngredientCommand, Ingredient>();
		CreateMap<PatchIngredientCommand, Ingredient>();
		CreateMap<PutIngredientCommand, Ingredient>();
	}
}

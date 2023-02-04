namespace Profit.Domain.Profiles;

public sealed class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeDTO, Recipe>().ReverseMap();
        CreateMap<CreateRecipeDTO, Recipe>();
    }
}

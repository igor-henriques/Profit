namespace Profit.Domain.Profiles;

public sealed class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeDto, Recipe>().ReverseMap();
        CreateMap<CreateRecipeCommand, Recipe>()
            .ForMember(x => x.IngredientRecipeRelations, y => y.MapFrom(src => src.IngredientRecipeRelations.Select(
                i => new IngredientRecipeRelation(i.MeasurementUnit).UpdateIngredientCount(i.IngredientCount)
                                                   .UpdateIngredientId(i.IngredientId))));

        CreateMap<PutRecipeCommand, Recipe>();
        CreateMap<IngredientRecipeRelation, IngredientRecipeRelationDto>().ReverseMap();
    }
}

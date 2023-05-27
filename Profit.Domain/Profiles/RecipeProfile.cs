namespace Profit.Domain.Profiles;

public sealed class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeDto, Recipe>().ReverseMap();
        CreateMap<CreateRecipeCommand, Recipe>()
            .ForMember(x => x.IngredientRecipeRelations, y => y.MapFrom(src => src.IngredientRecipeRelations.Select(
                i => new IngredientRecipeRelation().UpdateIngredientCount(i.IngredientCount)
                                                   .UpdateIngredientId(i.IngredientId)
                                                   .UpdateMeasurementUnit(i.MeasurementUnit))));

        CreateMap<PatchRecipeCommand, Recipe>();
        CreateMap<PutRecipeCommand, Recipe>();
        CreateMap<IngredientRecipeRelation, IngredientRecipeRelationDto>().ReverseMap();
    }
}

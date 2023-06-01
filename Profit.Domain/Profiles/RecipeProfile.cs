namespace Profit.Domain.Profiles;

public sealed class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeDto, Recipe>().ReverseMap();
        CreateMap<CreateRecipeCommand, Recipe>()
            .ForMember(x => x.IngredientRecipeRelations, y => y.MapFrom(src => src.IngredientRecipeRelations.Select(
                i => new IngredientRecipeRelation(i.MeasurementUnit)
                        .UpdateIngredientCount(i.IngredientCount)
                        .UpdateIngredientId(i.IngredientId))))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.TotalCost, opt => opt.Ignore());

        CreateMap<PutRecipeCommand, Recipe>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.TotalCost, opt => opt.Ignore());
        CreateMap<IngredientRecipeRelation, IngredientRecipeRelationDto>().ReverseMap();
    }
}

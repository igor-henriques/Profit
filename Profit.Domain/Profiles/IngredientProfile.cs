namespace Profit.Domain.Profiles;

public sealed class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        CreateMap<IngredientDto, Ingredient>()
            .ForMember(dest => dest.IngredientRecipeRelations, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<CreateIngredientCommand, Ingredient>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IngredientRecipeRelations, opt => opt.Ignore());
        CreateMap<PutIngredientCommand, Ingredient>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.IngredientRecipeRelations, opt => opt.Ignore());
    }
}

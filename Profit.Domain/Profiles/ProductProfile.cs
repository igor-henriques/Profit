namespace Profit.Domain.Profiles;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<PatchProductCommand, Product>();
        CreateMap<PutProductCommand, Product>();
    }
}

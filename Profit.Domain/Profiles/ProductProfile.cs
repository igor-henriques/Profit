namespace Profit.Domain.Profiles;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<CreateProductDTO, Product>();
    }
}

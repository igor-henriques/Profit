namespace Profit.Domain.Profiles;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<PutProductCommand, Product>();
    }
}

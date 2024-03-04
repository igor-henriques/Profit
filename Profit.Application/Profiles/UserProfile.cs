namespace Profit.Domain.Profiles;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.IsEmailVerified, opt => opt.Ignore())
            .ForMember(dest => dest.UserClaims, opt => opt.Ignore())
            .ForMember(dest => dest.HashedPassword, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserClaims, opt => opt.Ignore())
            .ForMember(dest => dest.TenantId, opt => opt.Ignore())
            .ForMember(dest => dest.IsEmailVerified, opt => opt.Ignore());

        CreateMap<PutUserCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.TenantId, opt => opt.Ignore())
            .ForMember(dest => dest.IsEmailVerified, opt => opt.Ignore())
            .ForMember(dest => dest.UserClaims, opt => opt.Ignore());
    }
}

namespace Profit.Domain.Profiles;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, User>().ReverseMap();

        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password));

        CreateMap<PatchUserCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password));

        CreateMap<PutUserCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password));  
    }
}

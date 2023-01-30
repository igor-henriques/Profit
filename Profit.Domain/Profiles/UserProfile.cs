namespace Profit.Domain.Profiles;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        //CreateMap<UserDTO, User>()
        //    .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Username))
        //    .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
        //    .ForMember(x => x.PasswordHash, opt => opt.MapFrom(x => x.Password));
    }
}

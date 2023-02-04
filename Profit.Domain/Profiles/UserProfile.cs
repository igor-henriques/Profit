namespace Profit.Domain.Profiles;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, User>().ReverseMap();
    }
}

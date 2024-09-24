using api.Dtos.AppUser;
using api.Models;

namespace api.Mappers;

public static class UserMappers
{
    public static UserResponseModel ToUserResponseModel(this AppUser appUser)
    {
        return new UserResponseModel
        {
            Id = appUser.Id,
            Username = appUser.UserName!,
            DisplayName = appUser.DisplayName,
            Avatar = appUser.Avatar
        };
    }
}
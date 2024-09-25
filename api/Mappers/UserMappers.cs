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
            DisplayName = appUser.DisplayName ?? appUser.UserName,
            Avatar = appUser.Avatar ?? string.Empty
        };
    }
}
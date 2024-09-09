using api.Dtos.User;
using api.Models;

namespace api.Mappers;

public static class UserMappers
{
    public static UserResponseModel ToUserResponseModel(User user)
    {
        return new UserResponseModel
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username
        };
    }

    public static User ToUser(UserRequestModel userRequestModel)
    {
        return new User()
        {
            Id = new Guid(),
            Email = userRequestModel.Email,
            Username = userRequestModel.Username,
            Bio = userRequestModel.Bio
        };
    }
}
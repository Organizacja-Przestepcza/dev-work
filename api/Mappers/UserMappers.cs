using api.Dtos.User;
using api.Models;

namespace api.Mappers;

public class UserMappers
{
    public UserResponseModel ToUserResponseModel(User user)
    {
        return new UserResponseModel
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username
        };
    }

    public User ToUser(UserRequestModel userRequestModel)
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
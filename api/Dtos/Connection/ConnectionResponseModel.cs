using api.Dtos.AppUser;

namespace api.Dtos.Connection;

public class ConnectionResponseModel
{
    public string Id { get; set; }
    public UserResponseModel Follower { get; set; } = null!;
    public UserResponseModel Following { get; set; } = null!;
}
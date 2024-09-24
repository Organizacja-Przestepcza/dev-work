using api.Dtos.AppUser;

namespace api.Dtos.Connection;

public class ConnectionResponseModel
{
    public required UserResponseModel Follower { get; set; }
    public required UserResponseModel Following { get; set; }
    public required DateTime CreatedAt { get; set; }
}
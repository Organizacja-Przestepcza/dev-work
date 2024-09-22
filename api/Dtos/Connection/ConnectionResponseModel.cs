using api.Dtos.AppUser;

namespace api.Dtos.Connection;

public class ConnectionResponseModel
{
    public required string Id { get; set; }
    public required UserResponseModel Follower { get; set; }
    public required UserResponseModel Following { get; set; }
}
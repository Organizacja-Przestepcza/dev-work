using api.Dtos.User;

namespace api.Dtos.Connection;

public class ConnectionResponseModel
{
    public Guid Id { get; set; }
    public UserResponseModel Follower { get; set; } = null!;
    public UserResponseModel Following { get; set; } = null!;
}
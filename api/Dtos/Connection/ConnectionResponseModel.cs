using api.Dtos.User;

namespace api.Dtos.Connection;

public class ConnectionResponseModel
{
    public Guid Id { get; set; }
    public Guid FollowerId { get; set; }
    public UserResponseModel Follower { get; set; } = null!;
    public Guid FollowingId { get; set; }
    public UserResponseModel Following { get; set; } = null!;
}
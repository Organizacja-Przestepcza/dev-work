using api.Dtos.User;

namespace api.Dtos.Connection;

public class GetConnectionDto
{
    public Guid Id { get; set; }
    public Guid FollowerId { get; set; }
    public GetUserDto Follower { get; set; } = null!;
    public Guid FollowingId { get; set; }
    public GetUserDto Following { get; set; } = null!;
}
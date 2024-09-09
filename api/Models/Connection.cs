namespace api.Models;

public class Connection
{
    public Guid Id { get; set; }
    public Guid FollowerId { get; set; }
    public User Follower { get; set; } = null!;
    public Guid FollowingId { get; set; }
    public User Following { get; set; } = null!;
}
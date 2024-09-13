namespace api.Models;

public class Connection
{
    public string Id { get; set; }
    public string FollowerId { get; set; }
    public AppUser Follower { get; set; } = null!;
    public string FollowingId { get; set; }
    public AppUser Following { get; set; } = null!;
}
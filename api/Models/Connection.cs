using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Connection
{
    [MaxLength(256)]
    public string Id { get; set; } = null!;

    [MaxLength(256)]
    public required string FollowerId { get; set; }
    public AppUser Follower { get; set; } = null!;
    [MaxLength(256)]
    public required string FollowingId { get; set; }

    public AppUser Following { get; set; } = null!;
}
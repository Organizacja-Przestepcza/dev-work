using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Connection
{
    [MaxLength(38)] public string Id { get; set; } = null!;

    [MaxLength(38)] public required string FollowerId { get; set; }

    public AppUser Follower { get; set; } = null!;

    [MaxLength(38)] public required string FollowingId { get; set; }

    public AppUser Following { get; set; } = null!;
}
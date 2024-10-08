using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Bookmark
{
    [MaxLength(38)] public required string PostId { get; set; }
    public Post Post { get; set; }
    [MaxLength(38)] public required string UserId { get; set; }
    public AppUser AppUser { get; set; }
    public DateTime CreatedAt { get; set; }
}
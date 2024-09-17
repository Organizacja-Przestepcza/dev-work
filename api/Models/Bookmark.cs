using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public class Bookmark
{
   [MaxLength(256)] public string Id { get; init; } = null!;

   [MaxLength(256)] public required string PostId { get; set; }
   public required Post Post { get; set; }
   [MaxLength(256)] public required string UserId { get; set; }
   public required AppUser AppUser { get; set; }
   public DateTime CreatedAt { get; set; }
}

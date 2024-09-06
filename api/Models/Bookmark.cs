using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public class Bookmark
{
   public Guid Id { get; set; }
   public Post Post { get; set; }
   public User User { get; set; }
   public DateTime CreatedAt { get; set; }
}

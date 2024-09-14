using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public class Bookmark
{
   public string Id { get; set; }
   public Post Post { get; set; }
   public AppUser AppUser { get; set; }
   public DateTime CreatedAt { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace api.Dtos.AppUser;

public class UserUpdateModel
{
    [MaxLength(256)] public string? Bio { get; set; }
    public string? Avatar { get; set; }
}
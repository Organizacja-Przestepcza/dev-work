using api.Dtos.Bookmark;
using api.Dtos.Connection;
using api.Models;

namespace api.Dtos.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public string Username { get; set; } = String.Empty;
 
}
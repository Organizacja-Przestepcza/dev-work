using api.Dtos.Bookmark;
using api.Dtos.Connection;
using api.Models;

namespace api.Dtos.User;

public class UserResponseModel
{
    public string Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
 
}
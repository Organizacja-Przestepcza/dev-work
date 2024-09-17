namespace api.Dtos.AppUser;

public class UserResponseModel
{
    public string Id { get; set; } = null!;
    public required string Email { get; set; }
    public required string Username { get; set; }
}
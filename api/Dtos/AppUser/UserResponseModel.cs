namespace api.Dtos.AppUser;

public class UserResponseModel
{
    public string Id { get; set; } = null!;
    public required string Username { get; set; }
    public string? DisplayName { get; set; }
    public string? Avatar { get; set; }
}
namespace api.Dtos.Account;

public class RegisterResponseModel
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }
}
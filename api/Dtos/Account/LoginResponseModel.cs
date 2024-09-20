namespace api.Dtos.Account;

public class LoginResponseModel
{
    public required string Email { get; set; }
    public required string Token { get; set; }
}
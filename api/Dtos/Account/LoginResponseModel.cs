namespace api.Dtos.Account;

public class LoginResponseModel
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}
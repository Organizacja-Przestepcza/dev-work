namespace api.Dtos.User;

public class UserRequestModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Bio { get; set; } = string.Empty;

}
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account;

public class LoginRequestModel
{
    [Required] public required string Username { get; set; }

    [Required] public required string Password { get; set; }
}
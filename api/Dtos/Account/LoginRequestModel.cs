using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account;

public class LoginRequestModel
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }

}
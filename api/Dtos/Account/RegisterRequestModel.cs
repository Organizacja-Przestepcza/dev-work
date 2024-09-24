using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account;

public class RegisterRequestModel
{
    [Required] [EmailAddress] public required string Email { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
    public required string Username { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public required string Password { get; set; }
}
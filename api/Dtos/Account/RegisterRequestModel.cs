using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account;

public class RegisterRequestModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
}
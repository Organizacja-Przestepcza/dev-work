using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Connection;

public class ConnectionRequestModel
{
    [Required] public required string FollowerId { get; set; }
    [Required] public required string FollowingId { get; set; }
}
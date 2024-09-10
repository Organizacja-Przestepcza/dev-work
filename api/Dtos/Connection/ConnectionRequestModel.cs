namespace api.Dtos.Connection;

public class ConnectionRequestModel
{
    public Guid FollowerId { get; set; }
    public Guid FollowingId { get; set; }
}
using api.Dtos.Connection;
using api.Models;

namespace api.Mappers;

public static class ConnectionMappers
{
    public static ConnectionResponseModel ToConnectionResponseModel(this Connection connection)
    {
        return new ConnectionResponseModel
        {
            Id = connection.Id,
            Follower = connection.Follower.ToUserResponseModel(),
            Following = connection.Following.ToUserResponseModel()
        };
    }

    public static Connection ToConnection(this ConnectionRequestModel connection)
    {
        return new Connection
        {
            FollowerId = connection.FollowerId,
            FollowingId = connection.FollowingId
        };
    }
}
using api.Dtos.Connection;
using api.Models;

namespace api.Mappers;

public static class ConnectionMappers
{
    public static ConnectionResponseModel ToConnectionResponseModel(this Connection? connection)
    {
        return new ConnectionResponseModel
        {
            Follower = connection.Follower.ToUserResponseModel(),
            Following = connection.Following.ToUserResponseModel(),
            CreatedAt = connection.CreatedAt
        };
    }
}
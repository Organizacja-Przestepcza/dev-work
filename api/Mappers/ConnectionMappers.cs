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

        };
    }

    public static Connection ToConnection(this ConnectionResponseModel connection)
    {
        return new Connection
        {
            Id = new Guid(),
        };
    }
}
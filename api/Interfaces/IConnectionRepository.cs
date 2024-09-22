using api.Dtos.Connection;
using api.Models;

namespace api.Interfaces;

public interface IConnectionRepository
{
    Task<List<Connection>> GetAllAsync();

    Task<Connection?> GetByIdAsync(string id);

    Task<Connection> CreateAsync(ConnectionRequestModel connectionRequestModel);

    Task<Connection?> DeleteAsync(string id);
}
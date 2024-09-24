using api.Dtos.Connection;
using api.Models;

namespace api.Interfaces;

public interface IConnectionRepository
{
    Task<List<Connection>> GetAllAsync();
    Task<List<Connection>> GetFollowers(string userId);
    Task<List<Connection>> GetFollowings(string userId);


    Task<Connection?> GetByIdAsync(string followerId, string followingId);

    Task<Connection?> CreateAsync(string followerId, string followingId);

    Task<Connection?> DeleteAsync(string followerId, string followingId);
}
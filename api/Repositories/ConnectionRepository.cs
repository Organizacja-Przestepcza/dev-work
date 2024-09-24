using api.Data;
using api.Dtos.Connection;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class ConnectionRepository : IConnectionRepository
{
    private readonly AppDbContext _context;

    public ConnectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Connection?>> GetAllAsync()
    {
        return await _context.Connections.ToListAsync();
    }


    public async Task<Connection?> GetByIdAsync(string followerId, string followingId)
    {
        return await _context.Connections.FirstOrDefaultAsync(c =>
            c!.FollowerId == followerId && c.FollowingId == followingId);
    }

    public async Task<Connection?> CreateAsync(string followerId, string followingId)
    {
        var connection = await GetByIdAsync(followerId, followingId);
        if (connection != null) return null;
        connection = new Connection
        {
            FollowingId = followingId,
            FollowerId = followerId,
            CreatedAt = DateTime.Now
        };
        await _context.Connections.AddAsync(connection);
        await _context.SaveChangesAsync();
        return connection;
    }

    public async Task<Connection?> DeleteAsync(string followerId, string followingId)
    {
        var connection = await GetByIdAsync(followerId, followingId);
        if (connection == null) return null;
        _context.Connections.Remove(connection);
        await _context.SaveChangesAsync();
        return connection;
    }
}
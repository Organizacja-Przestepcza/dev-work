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

    public async Task<List<Connection>> GetAllAsync()
    {
        return await _context.Connections.ToListAsync();
    }


    public async Task<Connection?> GetByIdAsync(string id)
    {
        return await _context.Connections.FindAsync(id);
    }

    public async Task<Connection> CreateAsync(ConnectionRequestModel connectionRequestModel)
    {
        var connection = connectionRequestModel.ToConnection();
        connection.Id = Guid.NewGuid().ToString();
        await _context.Connections.AddAsync(connection);
        await _context.SaveChangesAsync();
        return connection;
    }

    public async Task<Connection?> DeleteAsync(string id)
    {
        var connection = await _context.Connections.FindAsync(id);
        if (connection == null) return null;
        _context.Connections.Remove(connection);
        await _context.SaveChangesAsync();
        return connection;
    }
}
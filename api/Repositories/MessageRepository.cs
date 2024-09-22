using api.Data;
using api.Dtos.Message;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _context;

    public MessageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Message>> GetAllAsync()
    {
        return await _context.Messages.Include(m => m.Sender).ToListAsync();
    }

    public async Task<Message?> GetByIdAsync(string id)
    {
        return await _context.Messages.Include(m => m.Sender).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Message> CreateAsync(MessageRequestModel messageRequest, string userId)
    {
        var message = messageRequest.ToMessage();
        message.Id = Guid.NewGuid().ToString();
        message.UserId = userId;
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();
        return message;
    }

    public async Task<Message?> UpdateAsync(string id, MessageUpdateModel messageUpdate)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message == null) return null;
        message.Content = messageUpdate.Content;
        await _context.SaveChangesAsync();
        return message;
    }

    public async Task<Message?> DeleteAsync(string id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message == null) return null;
        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();
        return message;
    }
}
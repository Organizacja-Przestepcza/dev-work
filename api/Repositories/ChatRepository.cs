using api.Data;
using api.Dtos.Chat;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly AppDbContext _context;

    public ChatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Chat>> GetAllAsync()
    {
        return await _context.Chats.ToListAsync();
    }

    public async Task<Chat?> GetByIdAsync(string id)
    {
        return await _context.Chats.FindAsync(id);
    }

    public async Task<Chat> CreateAsync(ChatRequestModel chatRequest)
    {
        var chat = chatRequest.ToChat();
        chat.Id = Guid.NewGuid().ToString();
        await _context.Chats.AddAsync(chat);
        await _context.SaveChangesAsync();
        return chat;
    }

    public async Task<Chat?> UpdateAsync(string id, ChatUpdateModel chatUpdateModel)
    {
        var chat = await _context.Chats.FindAsync(id);
        if (chat == null) return null;
        chat.Name = chatUpdateModel.Name;
        await _context.SaveChangesAsync();
        return chat;
    }

    public async Task<Chat?> DeleteAsync(string id)
    {
        var chat = await _context.Chats.FindAsync(id);
        if (chat == null) return null;
        _context.Chats.Remove(chat);
        await _context.SaveChangesAsync();
        return chat;
    }
}
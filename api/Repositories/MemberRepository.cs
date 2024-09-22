using api.Data;
using api.Dtos.ChatMember;
using api.Enums;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;

    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ChatMember>> GetAllAsync()
    {
        return await _context.Members.ToListAsync();
    }
    public async Task<ChatMember?> GetByIdAsync(string id)
    {
        return await _context.Members.FindAsync(id);
    }
    public async Task<List<ChatMember>?> GetByUserAsync(string userId)
    {
        return await _context.Members.Where(m => m.UserId == userId).ToListAsync();
    }

    public async Task<bool> IsMemberAsync(string chatId, string userId)
    {
        return await _context.Members.AnyAsync(m => m.UserId == userId && m.ChatId == chatId);
    }

    public async Task<bool> IsPrivilegedAsync(string chatId, string userId)
    {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.UserId == userId && m.ChatId == chatId);
        return member?.Role is Role.Owner or Role.Admin;
    }

    public async Task<ChatMember> AddAsync(ChatMemberRequestModel chatMemberRequest)
    {
        var member = chatMemberRequest.ToMember();
        member.Id = Guid.NewGuid().ToString();
        await _context.Members.AddAsync(member);
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task<ChatMember?> UpdateAsync(string id, ChatMemberUpdateModel chatMemberUpdate)
    {
        var chatMember = await _context.Members.FindAsync(id);
        if (chatMember == null) return null;
        chatMember.Role = chatMemberUpdate.Role;
        await _context.SaveChangesAsync();
        return chatMember;
    }

    public async Task<ChatMember?> DeleteAsync(string id)
    {
        var chatMember = await _context.Members.FindAsync(id);
        if (chatMember == null) return null;
        _context.Members.Remove(chatMember);
        await _context.SaveChangesAsync();
        return chatMember;
    }
}
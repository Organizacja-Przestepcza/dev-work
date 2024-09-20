using api.Dtos.ChatMember;
using api.Models;

namespace api.Interfaces;

public interface IMemberRepository
{
    Task<List<ChatMember>> GetAllAsync();
    Task<ChatMember?> GetByIdAsync(string id);
    Task<ChatMember> AddAsync(ChatMemberRequestModel chatMemberRequest);
    Task<ChatMember?> UpdateAsync(string id, ChatMemberUpdateModel chatMemberUpdate);
    Task<ChatMember?> DeleteAsync(string id);
}
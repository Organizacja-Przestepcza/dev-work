using api.Dtos.ChatMember;
using api.Models;

namespace api.Interfaces;

public interface IMemberRepository
{
    Task<List<ChatMember>> GetAllAsync();
    Task<ChatMember?> GetByIdAsync(string id);
    Task<List<ChatMember>?> GetByUserAsync(string id);
    /// <summary>
    /// Checks whether a user is a member of a given chat 
    /// </summary>
    /// <param name="chatId">ID of chat</param>
    /// <param name="userId">ID of user</param>
    /// <returns><c>true</c> if user is a member, <c>false</c> otherwise</returns>
    Task<bool> IsMemberOfChatAsync(string chatId, string userId);
    Task<ChatMember> AddAsync(ChatMemberRequestModel chatMemberRequest);
    Task<ChatMember?> UpdateAsync(string id, ChatMemberUpdateModel chatMemberUpdate);
    Task<ChatMember?> DeleteAsync(string id);
}
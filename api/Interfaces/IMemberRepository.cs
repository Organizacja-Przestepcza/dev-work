using api.Dtos.ChatMember;
using api.Models;

namespace api.Interfaces;

public interface IMemberRepository
{
    Task<List<ChatMember>> GetAllAsync();
    Task<List<ChatMember>> GetByChatIdAsync(string id);
    Task<ChatMember?> GetByIdAsync(string id);
    Task<List<ChatMember>> GetByUserAsync(string id);

    /// <summary>
    ///     Checks whether a user is a member of a given chat
    /// </summary>
    /// <param name="chatId">ID of the chat</param>
    /// <param name="userId">ID of the user</param>
    /// <returns><c>true</c> if user is a member, <c>false</c> if they aren't</returns>
    Task<bool> IsMemberAsync(string chatId, string userId);

    /// <summary>
    ///     Checks whether a user has elevated privileges in a given chat
    /// </summary>
    /// <param name="chatId">ID of the chat</param>
    /// <param name="userId">ID of the user</param>
    /// <returns><c>true</c> if user is an admin or owner, <c>false</c> if they are neither</returns>
    Task<bool> IsPrivilegedAsync(string chatId, string userId);

    /// <summary>
    ///     Checks whether a user is an owner of a given chat
    /// </summary>
    /// <param name="chatId">ID of the chat</param>
    /// <param name="userId">ID of the user</param>
    /// <returns><c>true</c> if user is an owner, <c>false</c> if they aren't</returns>
    Task<bool> IsOwnerAsync(string chatId, string userId);

    Task<ChatMember> AddAsync(ChatMemberRequestModel chatMemberRequest);
    Task<ChatMember?> UpdateAsync(string id, ChatMemberUpdateModel chatMemberUpdate);
    Task<ChatMember?> DeleteAsync(string id);
}
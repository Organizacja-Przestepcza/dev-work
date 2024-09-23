using api.Dtos.Chat;
using api.Models;

namespace api.Interfaces;

public interface IChatRepository
{
    Task<List<Chat>> GetAllForUserAsync(string userId);

    Task<Chat?> GetByIdAsync(string id);

    Task<Chat> CreateAsync(ChatRequestModel chat);

    Task<Chat?> UpdateAsync(string id, ChatUpdateModel chatUpdateModel);

    /// <summary>
    /// Deletes asynchronously a chat with all related <c>Members</c> and <c>Messages</c>.
    /// Use with caution!
    /// </summary>
    /// <param name="id">ID of a chat to be deleted</param>
    /// <returns></returns>
    Task<Chat?> DeleteAsync(string id);
}
using api.Dtos.Message;
using api.Models;

namespace api.Interfaces;

public interface IMessageRepository
{
    Task<List<Message>> GetAllAsync(string chatId);

    Task<Message?> GetByIdAsync(string id);

    Task<Message> CreateAsync(MessageRequestModel messageRequest, string userId);

    Task<Message?> UpdateAsync(string id, MessageUpdateModel messageUpdate);
    Task<Message?> DeleteAsync(string id);
}
using api.Dtos.Message;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IMessageRepository
{
    Task<List<Message>> GetAllAsync();

    Task<Message?> GetByIdAsync(string id);

    Task<Message> CreateAsync(MessageRequestModel messageRequest);

    Task<Message?> UpdateAsync(string id, MessageUpdateModel messageUpdate);
    Task<Message?> DeleteAsync(string id);
}
using api.Dtos.Message;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IMessageRepository
{
    Task<List<Message>> GetAllAsync();

    Task<Message?> GetByIdAsync(string id);

    Task<Message> CreateAsync(MessageRequestModel messageRequest);

    Task<Message?> UpdateAsync(Message message);
    Task<Message?> DeleteAsync(string id);
}
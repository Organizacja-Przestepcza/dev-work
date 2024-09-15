using api.Dtos.Message;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IMessageRepository
{
    Task<List<Message>> GetAll();

    Task<Message?> GetById(string id);

    Task<Message> Add(MessageRequestModel messageRequest);

    Task<Message?> Update(Message message);
    Task<Message?> Delete(string id);
}
using api.Dtos.Chat;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IChatRepository
{
    Task<List<Chat>> GetAllAsync();

    Task<Chat?> GetByIdAsync(string id);

    Task<Chat> CreateAsync(ChatRequestModel chat);

    Task<Chat?> UpdateAsync(string id, ChatUpdateModel chatUpdateModel);
    Task<Chat?> DeleteAsync(string id);
}
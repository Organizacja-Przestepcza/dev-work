using api.Dtos.Chat;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IChatRepository
{
    Task<List<Chat>> GetAll();

    Task<Chat?> GetById(string id);

    Task<Chat> Add(Chat chat);

    Task<Chat?> Update(Chat chat);
    Task<Chat?> Delete(string id);
}
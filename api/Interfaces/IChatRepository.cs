using api.Dtos.Chat;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IChatRepository
{
    public Task<IActionResult> GetAll();

    public Task<IActionResult> GetById(string id);

    public Task<IActionResult> Add(ChatRequestModel chatRequest);

    public Task<IActionResult> Update(Chat chat);
    public Task<IActionResult> Delete(string id);
}
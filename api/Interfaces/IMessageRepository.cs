using api.Dtos.Message;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IMessageRepository
{
    public Task<IActionResult> GetAll();

    public Task<IActionResult> GetById(string id);

    public Task<IActionResult> Add(MessageRequestModel messageRequest);

    public Task<IActionResult> Update(Message message);
    public Task<IActionResult> Delete(string id);
}
using api.Dtos.PostInteraction;
using api.Models;

namespace api.Interfaces;

public interface IPostInteractionRepository
{
    Task<List<PostInteraction>> GetAllAsync();

    Task<PostInteraction?> GetByIdAsync(string id);

    Task<PostInteraction> CreateAsync(PostInteractionRequestModel postInteractionRequest);
    Task<PostInteraction?> UpdateAsync(string id, PostInteractionUpdateModel postInteractionUpdate);
    Task<PostInteraction?> DeleteAsync(string id);
}
using api.Dtos.PostInteraction;
using api.Models;

namespace api.Interfaces;

public interface IPostInteractionRepository
{
    Task<PostInteractionSummaryModel> GetAllForPostAsync(string postId);
    Task<List<PostInteraction>> GetAllForUserAsync(int type, string userId);
    Task<PostInteraction?> GetByIdAsync(string postId, string userId);

    Task<PostInteraction?> CreateUpdateAsync(PostInteractionUpdateModel postInteractionUpdate);
    Task<PostInteraction?> DeleteAsync(string postId, string userId);
}
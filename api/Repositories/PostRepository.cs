using api.Data;
using api.Dtos.AppUser;
using api.Dtos.Post;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PostResponseModel>> GetAllOffsetAsync(PaginationQuery query)
    {
        var skip = query.Page * query.Limit;
        return await _context.Posts
            .Where(p => p.PreviousPostId == null)
            .OrderByDescending(p => p.CreatedAt)
            .Skip(skip)
            .Take(query.Limit)
            .Select(p => new PostResponseModel
            {
                Id = p.Id,
                Content = p.Content,
                CreatedAt = p.CreatedAt,
                EditedAt = p.EditedAt,
                CommentCount = _context.Posts.Count(c => c.PreviousPostId == p.Id),
                ImageUrls = p.Images,
                PreviousPostId = p.PreviousPostId
            })
            .ToListAsync();
    }

    public async Task<List<Post>> GetCommentsOffsetAsync(string id, PaginationQuery query)
    {
        var skip = query.Page * query.Limit;
        return await _context.Posts.Where(p => p.PreviousPostId == id).OrderBy(p => p.CreatedAt).Skip(skip)
            .Take(query.Limit).ToListAsync();
    }

    public async Task<Post?> GetByIdAsync(string id)
    {
        return await _context.Posts.FindAsync(id);
    }

    public async Task<Post> CreateAsync(PostRequestModel postRequest, string userId)
    {
        var post = postRequest.ToPost();
        post.Id = Guid.NewGuid().ToString();
        post.UserId = userId;
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> UpdateAsync(string id, PostUpdateModel postUpdate)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return null;
        post.Content = postUpdate.Content;
        post.EditedAt = DateTime.Now;
        post.Images = postUpdate.ImageUrls;
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> DeleteAsync(string id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return null;
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return post;
    }
}
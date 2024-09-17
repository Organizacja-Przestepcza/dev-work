using api.Data;
using api.Dtos.Post;
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
    public async Task<List<Post>> GetAllAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<Post?> GetByIdAsync(string id)
    {
        return await _context.Posts.FindAsync(id); 
    }

    public async Task<Post> CreateAsync(PostRequestModel postRequest)
    {
        var post = postRequest.ToPost();
        post.Id = new Guid().ToString();
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> UpdateAsync(string id, PostUpdateModel postUpdate)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return null;
        }
        post.Content = postUpdate.Content;
        post.EditedAt = DateTime.Now;
        post.Images = postUpdate.ImageUrls;
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> DeleteAsync(string id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return null;
        }
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return post;
    }
}
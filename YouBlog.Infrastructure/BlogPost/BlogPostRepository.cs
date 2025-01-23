using Microsoft.EntityFrameworkCore;
using YouBlog.Infrastructure.Database;

namespace YouBlog.Infrastructure.BlogPost;

/// <summary>
/// <see cref="IBlogPostRepository"/> implementation using Entity Framework Core. 
/// </summary>
public class BlogPostRepository : IBlogPostRepository
{
    private readonly YouBlogDbContext _context;

    public BlogPostRepository(YouBlogDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<BlogPostDAO>> GetAll()
    {
        return await _context.BlogPosts.Include(bp => bp.Comments).ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<BlogPostDAO?> GetById(long id)
    {
        return await _context.BlogPosts.Include(bp => bp.Comments).FirstOrDefaultAsync(bp => bp.Id == id);
    }

    /// <inheritdoc/>
    public async Task<BlogPostDAO> Create(BlogPostDAO blogPost)
    {
        _context.BlogPosts.Add(blogPost);
        await _context.SaveChangesAsync();
        return blogPost;
    }

    /// <inheritdoc/>
    public async Task<BlogPostDAO> Update(long id, BlogPostDAO blogPost)
    {
        var existingBlogPost = await _context.BlogPosts.Include(bp => bp.Comments).FirstOrDefaultAsync(bp => bp.Id == id);
        if (existingBlogPost == null)
        {
            return null;
        }

        existingBlogPost.Title = blogPost.Title;
        existingBlogPost.Content = blogPost.Content;
        existingBlogPost.UpdatedAt = blogPost.UpdatedAt;
        existingBlogPost.Comments = blogPost.Comments;

        await _context.SaveChangesAsync();
        return existingBlogPost;
    }

    /// <inheritdoc/>
    public async Task Delete(long id)
    {
        var blogPost = await _context.BlogPosts.Include(bp => bp.Comments).FirstOrDefaultAsync(bp => bp.Id == id);
        if (blogPost != null)
        {
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
        }
    }
    
    /// <inheritdoc/>
    public async Task<CommentDAO?> AddComment(long blogPostId, CommentDAO comment)
    {
        var blogPost = await _context.BlogPosts.Include(bp => bp.Comments).FirstOrDefaultAsync(bp => bp.Id == blogPostId);

        if (blogPost is null)
            throw new ArgumentException("Blog post not found.");

        blogPost.Comments ??= new();
        
        comment.BlogPostId = blogPostId;
        blogPost.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return comment;
    }
}
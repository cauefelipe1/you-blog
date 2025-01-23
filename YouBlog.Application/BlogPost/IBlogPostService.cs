using YouBlog.Models.BlogPost;

namespace YouBlog.Application.BlogPost;

public interface IBlogPostService
{
    Task<IEnumerable<BlogPostModel>> GetAll();
    Task<BlogPostModel> GetById(long id);
    Task<BlogPostModel> Create(BlogPostModel blogPost);
    Task<BlogPostModel> Update(long id, BlogPostModel blogPost);
    Task Delete(long id);
}
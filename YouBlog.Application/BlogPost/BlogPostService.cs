using YouBlog.Infrastructure.BlogPost;
using YouBlog.Models.BlogPost;

namespace YouBlog.Application.BlogPost;

public class BlogPostService : IBlogPostService
{
    private readonly IBlogPostRepository _repository;

    public BlogPostService(IBlogPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BlogPostModel>> GetAll()
    {
        var daos = await _repository.GetAll();
        return daos.Select(BuildModel);
    }

    public async Task<BlogPostModel> GetById(long id)
    {
        var dao = await _repository.GetById(id);
        return dao == null ? null : BuildModel(dao);
    }

    public async Task<BlogPostModel> Create(BlogPostModel blogPost)
    {
        var dao = BuildDAO(blogPost);
        var createdDao = await _repository.Create(dao);
        return BuildModel(createdDao);
    }

    public async Task<BlogPostModel> Update(long id, BlogPostModel blogPost)
    {
        var dao = BuildDAO(blogPost);
        var updatedDao = await _repository.Update(id, dao);
        return updatedDao == null ? null : BuildModel(updatedDao);
    }

    public async Task Delete(long id)
    {
        await _repository.Delete(id);
    }

    private BlogPostModel BuildModel(BlogPostDAO dao)
    {
        return new BlogPostModel
        {
            Id = dao.Id,
            Title = dao.Title,
            Content = dao.Content,
            CreatedAt = dao.CreatedAt,
            UpdatedAt = dao.UpdatedAt,
            TotalComments = dao.Comments?.Count ?? 0,
            Comments = dao.Comments?.Select(comment => new CommentModel
            {
                Id = comment.Id,
                Author = comment.Author,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                BlogPostId = comment.BlogPostId
            }).ToList()
        };
    }

    private BlogPostDAO BuildDAO(BlogPostModel model)
    {
        return new BlogPostDAO
        {
            Id = model.Id,
            Title = model.Title,
            Content = model.Content,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Comments = model.Comments?.Select(comment => new CommentDAO
            {
                Id = comment.Id,
                Author = comment.Author,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                BlogPostId = comment.BlogPostId
            }).ToList()
        };
    }
}
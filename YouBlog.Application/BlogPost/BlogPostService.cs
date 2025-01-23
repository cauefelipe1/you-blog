using YouBlog.Infrastructure.BlogPost;
using YouBlog.Models.BlogPost;

namespace YouBlog.Application.BlogPost;

/// <summary>
/// <see cref="IBlogPostService"/> implementation using the <see cref="IBlogPostService"/>.
/// </summary>
public class BlogPostService : IBlogPostService
{
    private readonly IBlogPostRepository _repository;

    public BlogPostService(IBlogPostRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<BlogPostModel>> GetAll()
    {
        var daos = await _repository.GetAll();
        return daos.Select(BuildModel);
    }

    /// <inheritdoc/>
    public async Task<BlogPostModel?> GetById(long id)
    {
        var dao = await _repository.GetById(id);
        return dao == null ? null : BuildModel(dao);
    }

    /// <inheritdoc/>
    public async Task<BlogPostModel> Create(BlogPostModel blogPost)
    {
        var dao = BuildDAO(blogPost);
        var createdDao = await _repository.Create(dao);
        return BuildModel(createdDao);
    }

    /// <inheritdoc/>
    public async Task<BlogPostModel> Update(long id, BlogPostModel blogPost)
    {
        var dao = BuildDAO(blogPost);
        var updatedDao = await _repository.Update(id, dao);
        return updatedDao == null ? null : BuildModel(updatedDao);
    }

    /// <inheritdoc/>
    public async Task Delete(long id)
    {
        await _repository.Delete(id);
    }

    /// <inheritdoc/>
    private BlogPostModel BuildModel(BlogPostDAO dao)
    {
        return new BlogPostModel
        {
            Id = dao.Id,
            Title = dao.Title,
            Content = dao.Content,
            CreatedAt = dao.CreatedAt ?? DateTimeOffset.Now,
            UpdatedAt = DateTimeOffset.Now,
            TotalComments = dao.Comments?.Count ?? 0,
            Comments = dao.Comments?.Select(comment => BuildCommentModel(comment)).ToList()
        };
    }

    /// <inheritdoc/>
    private BlogPostDAO BuildDAO(BlogPostModel model)
    {
        return new BlogPostDAO
        {
            Id = model.Id == 0 ? null : model.Id,
            Title = model.Title,
            Content = model.Content,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Comments = model.Comments?.Select(comment => BuildCommentDAO(comment)).ToList()
        };
    }
    
    private CommentDAO BuildCommentDAO(CommentModel model)
    {
        return new CommentDAO
        {
            Id = model.Id == 0 ? null : model.Id,
            Author = model.Author,
            Content = model.Content,
            CreatedAt = model.CreatedAt ?? DateTimeOffset.Now,
            BlogPostId = model.BlogPostId
        };
    }

    private CommentModel BuildCommentModel(CommentDAO dao)
    {
        return new CommentModel
        {
            Id = dao.Id,
            Author = dao.Author,
            Content = dao.Content,
            CreatedAt = dao.CreatedAt,
            BlogPostId = dao.BlogPostId
        };
    }

    /// <inheritdoc/>
    public async Task<CommentModel?> AddComment(long blogPostId, CommentModel comment)
    {
        var commentDAO = BuildCommentDAO(comment);

        var addedComment = await _repository.AddComment(blogPostId, commentDAO);
        
        if (addedComment is null)
            return null;

        var result = BuildCommentModel(addedComment);

        return result;
    }
}
using YouBlog.Models.BlogPost;

namespace YouBlog.Application.BlogPost;

public interface IBlogPostService
{
    /// <summary>
    /// Retrieves all blog posts.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of BlogPostModel.</returns>
    Task<IEnumerable<BlogPostModel>> GetAll();

    /// <summary>
    /// Retrieves a blog post by its ID.
    /// </summary>
    /// <param name="id">The ID of the blog post to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the BlogPostModel.</returns>
    Task<BlogPostModel?> GetById(long id);

    /// <summary>
    /// Creates a new blog post.
    /// </summary>
    /// <param name="blogPost">The blog post to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created BlogPostModel.</returns>
    Task<BlogPostModel> Create(BlogPostModel blogPost);

    /// <summary>
    /// Updates an existing blog post.
    /// </summary>
    /// <param name="id">The ID of the blog post to update.</param>
    /// <param name="blogPost">The updated blog post data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated BlogPostModel.</returns>
    Task<BlogPostModel> Update(long id, BlogPostModel blogPost);

    /// <summary>
    /// Deletes a blog post by its ID.
    /// </summary>
    /// <param name="id">The ID of the blog post to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Delete(long id);
    
    /// <summary>
    /// Adds a comment to a blog post.
    /// </summary>
    /// <param name="blogPostId">The ID of the blog post to add the comment to.</param>
    /// <param name="comment">The comment to add.</param>
    /// <returns>The added CommentModel.</returns>
    Task<CommentModel?> AddComment(long blogPostId, CommentModel comment);
}
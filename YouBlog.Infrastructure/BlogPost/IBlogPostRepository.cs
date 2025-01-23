namespace YouBlog.Infrastructure.BlogPost;

public interface IBlogPostRepository
{
    /// <summary>
    /// Retrieves all blog posts.
    /// </summary>
    /// <returns>A collection of BlogPostDAO.</returns>
    Task<IEnumerable<BlogPostDAO>> GetAll();

    /// <summary>
    /// Retrieves a blog post by its ID.
    /// </summary>
    /// <param name="id">The ID of the blog post to retrieve.</param>
    /// <returns>The BlogPostDAO when the ID exists. Null otherwise.</returns>
    Task<BlogPostDAO?> GetById(long id);

    /// <summary>
    /// Creates a new blog post.
    /// </summary>
    /// <param name="blogPost">The blog post to create.</param>
    /// <returns>The created BlogPostDAO.</returns>
    Task<BlogPostDAO> Create(BlogPostDAO blogPost);

    /// <summary>
    /// Updates an existing blog post.
    /// </summary>
    /// <param name="id">The ID of the blog post to update.</param>
    /// <param name="blogPost">The updated blog post data.</param>
    /// <returns>The updated BlogPostDAO.</returns>
    Task<BlogPostDAO> Update(long id, BlogPostDAO blogPost);

    /// <summary>
    /// Deletes a blog post by its ID.
    /// </summary>
    /// <param name="id">The ID of the blog post to delete.</param>
    Task Delete(long id);
}
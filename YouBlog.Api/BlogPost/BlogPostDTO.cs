namespace YouBlog.Api.BlogPost;

/// <summary>
/// Represents a blog post.
/// </summary>
public class BlogPostDTO
{
    /// <summary>
    /// The unique identifier for the blog post.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    /// The title of the blog post.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The content of the blog post.
    /// </summary>
    public string Content { get; set; }
}

/// <summary>
/// Represents a comment on a blog post.
/// </summary>
public class CommentDTO
{
    /// <summary>
    /// The unique identifier for the comment.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    /// The author of the comment.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// The content of the comment.
    /// </summary>
    public string Content { get; set; }
}
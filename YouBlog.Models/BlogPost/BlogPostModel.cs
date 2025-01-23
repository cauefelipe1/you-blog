namespace YouBlog.Models.BlogPost
{
    /// <summary>
    /// Represents a blog post.
    /// </summary>
    public class BlogPostModel
    {
        /// <summary>
        /// The unique identifier for the blog post.
        /// </summary>
        public long Id { get; set; }
    
        /// <summary>
        /// The title of the blog post.
        /// </summary>
        public string Title { get; set; }
    
        /// <summary>
        /// The content of the blog post.
        /// </summary>
        public string Content { get; set; }
    
        /// <summary>
        /// The date and time when the blog post was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
    
        /// <summary>
        /// The date and time when the blog post was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }
        
        /// <summary>
        /// The amount of comments associated with the blog post.
        /// </summary>
        public int TotalComments { get; set; }
    
        /// <summary>
        /// The list of comments associated with the blog post.
        /// </summary>
        public List<CommentModel>? Comments { get; set; }
    }

    /// <summary>
    /// Represents a comment on a blog post.
    /// </summary>
    public class CommentModel
    {
        /// <summary>
        /// The unique identifier for the comment.
        /// </summary>
        public long Id { get; set; }
    
        /// <summary>
        /// The author of the comment.
        /// </summary>
        public string Author { get; set; }
    
        /// <summary>
        /// The content of the comment.
        /// </summary>
        public string Content { get; set; }
    
        /// <summary>
        /// The date and time when the comment was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
    
        /// <summary>
        /// The unique identifier of the blog post that the comment is associated with.
        /// </summary>
        public long BlogPostId { get; set; }
    }
}
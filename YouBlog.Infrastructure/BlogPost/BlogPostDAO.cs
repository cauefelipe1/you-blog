namespace YouBlog.Infrastructure.BlogPost
{
    public class BlogPostDAO
    {
        
        public long? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public List<CommentDAO>? Comments { get; set; }
    }

    public class CommentDAO
    {
        public long? Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public long? BlogPostId { get; set; }
    }
}
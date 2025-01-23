using YouBlog.Api.BlogPost;
using YouBlog.Models.BlogPost;

namespace YouBlog.Api.Extensions;

public static class DTOsExtensions
{
    public static BlogPostModel ToModel(this BlogPostDTO dto)
    {
        return new BlogPostModel
        {
            Id = dto.Id,
            Title = dto.Title,
            Content = dto.Content,
            Comments = dto.Comments?.Select(c => c.ToModel()).ToList()
        };
    }

    public static CommentModel ToModel(this CommentDTO dto)
    {
        return new CommentModel
        {
            Id = dto.Id,
            Author = dto.Author,
            Content = dto.Content,
            // BlogPostId = dto.BlogPostId
        };
    }
}
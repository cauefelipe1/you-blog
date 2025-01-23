using YouBlog.Api.BlogPost;
using YouBlog.Models.BlogPost;

namespace YouBlog.Api.Extensions;

/// <summary>
/// Class to hold extension methods for DTOs.
/// </summary>
public static class DTOsExtensions
{
    /// <summary>
    /// Converts a BlogPostDTO to a BlogPostModel.
    /// </summary>
    /// <param name="dto">The BlogPostDTO to convert.</param>
    /// <returns>The converted BlogPostModel.</returns>
    public static BlogPostModel ToModel(this BlogPostDTO dto)
    {
        return new BlogPostModel
        {
            Id = dto.Id,
            Title = dto.Title,
            Content = dto.Content
        };
    }

    /// <summary>
    /// Converts a CommentDTO to a CommentModel.
    /// </summary>
    /// <param name="dto">The CommentDTO to convert.</param>
    /// <returns>The converted CommentModel.</returns>
    public static CommentModel ToModel(this CommentDTO dto)
    {
        return new CommentModel
        {
            Id = dto.Id,
            Author = dto.Author,
            Content = dto.Content
        };
    }
}
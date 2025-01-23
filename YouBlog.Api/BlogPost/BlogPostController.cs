using Microsoft.AspNetCore.Mvc;
using YouBlog.Api.Extensions;
using YouBlog.Application.BlogPost;
using YouBlog.Models.BlogPost;

namespace YouBlog.Api.BlogPost
{
    [ApiController]
    [Route("api/posts")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _service;
        
        public BlogPostController(IBlogPostService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all blog posts.
        /// </summary>
        /// <returns>A list of blog posts.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BlogPostModel>), 200)]
        public async Task<ActionResult<IEnumerable<BlogPostModel>>> GetAllPosts()
        {
            var posts = await _service.GetAll();

            return Ok(posts);
        }

        /// <summary>
        /// Creates a new blog post.
        /// </summary>
        /// <param name="newPostModel">The new blog post model.</param>
        /// <returns>The created blog post.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BlogPostModel), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BlogPostModel>> CreatePost([FromBody] BlogPostDTO newPostModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var createdPost = await _service.Create(newPostModel.ToModel());

            return CreatedAtAction(
                nameof(GetPostById),
                new { id = createdPost.Id },
                createdPost);
        }

        /// <summary>
        /// Gets a blog post by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog post.</param>
        /// <returns>The blog post with the specified ID.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogPostModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BlogPostModel>> GetPostById(long id)
        {
            if (id <= 0)
                return BadRequest();

            var post = await _service.GetById(id);

            if (post is null)
                return NotFound();

            return Ok(post);
        }

        /// <summary>
        /// Adds a comment to a blog post.
        /// </summary>
        /// <param name="blogpostId">The ID of the blog post.</param>
        /// <param name="newComment">The new comment model.</param>
        /// <returns>The added comment.</returns>
        [HttpPost("{id}/comments")]
        [ProducesResponseType(typeof(CommentModel), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CommentModel>> AddComment(
            [FromRoute(Name = "id")] long blogpostId,
            [FromBody] CommentDTO newComment)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var comment = await _service.AddComment(blogpostId, newComment.ToModel());

                return CreatedAtAction(nameof(GetPostById), new { id = blogpostId }, comment);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
    }
}
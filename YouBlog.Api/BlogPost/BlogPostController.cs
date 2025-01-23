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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostModel>>> GetAllPosts()
        {
            var posts = await _service.GetAll();

            return Ok(posts);
        }

        [HttpPost]
        public ActionResult<BlogPostModel> CreatePost([FromBody] BlogPostDTO newPostModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var createdPost = _service.Create(newPostModel.ToModel());
            
            return CreatedAtAction(
                nameof(GetPostById), 
                new { id = createdPost.Id }, 
                createdPost);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostModel>> GetPostById(long id)
        {
            if (id <= 0)
                return BadRequest();

            var post = await _service.GetById(id);
            
            if (post is null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost("{blogpostId}/comments")]
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
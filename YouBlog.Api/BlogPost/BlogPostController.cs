using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<BlogPostModel> CreatePost([FromBody] BlogPostModel newPostModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var createdPost = _blogPostDAO.Create(newPostModel);
            
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);
        }

        [HttpGet("{id}")]
        public ActionResult<BlogPostModel> GetPostById(long id)
        {
            var post = _blogPostDAO.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost("{id}/comments")]
        public ActionResult<CommentModel> AddComment(long id, [FromBody] CommentModel newCommentModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var post = _blogPostDAO.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            newCommentModel.BlogPostId = id;
            var createdComment = _blogPostDAO.AddComment(newCommentModel);
            return CreatedAtAction(nameof(GetPostById), new { id = id }, createdComment);
        }
    }
}
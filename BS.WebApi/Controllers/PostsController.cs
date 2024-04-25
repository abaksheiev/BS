using BS.Repositories.DTOs.Queries;
using BS.Repositories.Models;
using BS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BS.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("{postId}")]
        public IEnumerable<PostModel> Get(Guid postId)
        {
            var query = new GetPostByIdQuery() {
                PostId = postId
            };

           return new
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] PostModel model)
        {
            var query = new GetPostByIdQuery()

        }
    }
}

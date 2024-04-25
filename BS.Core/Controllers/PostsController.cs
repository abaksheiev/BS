using BS.Application.Posts.Queries;
using BS.Core.Controllers;
using BS.Application.Posts.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BS.Contracts.ApiDtos;
using BS.Contracts.PostAggregations;
using BS.Contracts.PostAggregations.Validators;

namespace BS.Contracts.PostAggregations.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PostsController : BaseController
    {
        private readonly ILogger<PostsController> _logger;
        private readonly IValidator<PostApiDto> _postValidator;
       

        public PostsController(ILogger<PostsController> logger, IValidator<PostApiDto> postValidator, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _postValidator = postValidator ?? throw new ArgumentNullException(nameof(postValidator));
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("{postId}")]
        public async Task<IActionResult> Get(Guid postId, [FromQuery]bool isAuthorInclude)
        {
            var query = GetPostByIdQuery.Create(postId, isAuthorInclude);

            var result = await Mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PostApiDto>(result));
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] PostApiDto model)
        {
            if (_postValidator.Validate(model, out List<string> errors))
            {
                return BadRequest(new { errors });
            }

            var modelDto = Mapper.Map<PostDto>(model);

            var command = CreatingPostCommand.Create(modelDto);

            var result = await Mediator.Send(command);

            return Ok(Mapper.Map<PostApiDto>(result));
        }
    }
}

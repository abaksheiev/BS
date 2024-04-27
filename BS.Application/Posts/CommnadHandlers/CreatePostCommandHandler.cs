using AutoMapper;
using BS.Contracts.PostAggregations;
using BS.Domain;
using BS.Application.Posts.Commands;
using MediatR;

namespace BS.Application.Posts.CommandHandlers
{
    public class CreatePostCommandHandler(PostAggregate postAggregate, IMapper _mapper)
        : IRequestHandler<CreatingPostCommand, PostDto>
    {

        async Task<PostDto> IRequestHandler<CreatingPostCommand, PostDto>.Handle(CreatingPostCommand request, CancellationToken cancellationToken)
        {
            // Build DTO from Request
            var dtoPost = _mapper.Map<PostDto>(request);

            // Crate Post
            var post = postAggregate.CreatePost(dtoPost);

            // Return created post
            return await postAggregate.GetPostById(post, true);
        }
    }
}

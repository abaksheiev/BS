using AutoMapper;
using BS.Contracts.PostAggregations;
using BS.Domain;
using BS.Application.Posts.Commands;
using MediatR;
using BS.Contracts.Repositories;
using BS.Application.Models;

namespace BS.Application.Posts.CommandHandlers
{
    public class CreatePostCommandHandler(IPostRepository postRepository, IMapper _mapper)
        : IRequestHandler<CreatingPostCommand, PostDto>
    {

        async Task<PostDto> IRequestHandler<CreatingPostCommand, PostDto>.Handle(CreatingPostCommand request, CancellationToken cancellationToken)
        {
            // Build DTO from Request
            var dtoPost = _mapper.Map<PostDto>(request);

            // Crate Post
            var postAggregate = PostAggregateRoot.Create(dtoPost,postRepository, _mapper);
            if (request.Author != null) {
                postAggregate.AddAuthor(request.Author);
            }

            postAggregate.Save();
            
            // Return created post
            return await postAggregate.GetPostById(postAggregate.Post.Id, true);
        }
    }
}

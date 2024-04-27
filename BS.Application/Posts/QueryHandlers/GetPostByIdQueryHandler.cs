
using AutoMapper;
using BS.Application.Posts.Queries;
using BS.Contracts.PostAggregations;
using BS.Contracts.Repositories;
using BS.Domain;
using MediatR;

namespace BS.Application.Posts.QueryHandlers
{
    public class GetPostByIdQueryHandler(IPostRepository _postRepository, IMapper _mapper) 
        : IRequestHandler<GetPostByIdQuery, PostDto>
    {
        async Task<PostDto> IRequestHandler<GetPostByIdQuery, PostDto>.Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var postAggregate = PostAggregateRoot.Create(_postRepository, _mapper);
          
            // Return created post
            return await postAggregate.GetPostById(request.PostId, request.IsIncludeAuthor);
        }
    }
}

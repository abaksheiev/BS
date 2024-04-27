
using AutoMapper;
using BS.Application.Posts.Queries;
using BS.Contracts.PostAggregations;
using BS.Domain;
using MediatR;

namespace BS.Application.Posts.QueryHandlers
{
    public class GetPostByIdQueryHandler(PostAggregate _postAggregate, IMapper _mapper) : IRequestHandler<GetPostByIdQuery, PostDto>
    {
        async Task<PostDto> IRequestHandler<GetPostByIdQuery, PostDto>.Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            // Return created post
            return await _postAggregate.GetPostById(request.PostId, request.IsIncludeAuthor);
        }
    }
}

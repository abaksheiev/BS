
using AutoMapper;
using BS.Repositories.Posts.Queries;
using BS.Contracts.PostAggregations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BS.Repositories.Posts.QueryHandlers
{
    public class GetPostByIdQueryHandler(BlogContext _ctx, IMapper _mapper) : IRequestHandler<GetPostByIdQuery, PostDto>
    {
        async Task<PostDto> IRequestHandler<GetPostByIdQuery, PostDto>.Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var postId = request.PostId;

            var query = _ctx.Posts.AsQueryable();

            if (request.IsIncludeAuthor)
            {
                query = query.Include(p => p.Author);
            }

            var post = await query.FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null)
            {
                return default;
            }

            return _mapper.Map<PostDto>(post);
        }
    }
}

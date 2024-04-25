using AutoMapper;
using BS.Application.Models;
using BS.Application.Posts.Commands;
using BS.Contracts.PostAggregations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BS.Application.Posts.CommandHandlers
{
    public class CreatePostCommandHandler(BlogContext _ctx, IMapper _mapper)
        : IRequestHandler<CreatingPostCommand, PostDto>
    {

        async Task<PostDto> IRequestHandler<CreatingPostCommand, PostDto>.Handle(CreatingPostCommand request, CancellationToken cancellationToken)
        {
            var dbModel = _mapper.Map<Post>(request);

            _ctx.Posts.Add(dbModel);

            await _ctx.SaveChangesAsync();

           
            return _mapper.Map<PostDto>(dbModel);
        }
    }
}

using BS.Contracts.PostAggregations;
using MediatR;

namespace BS.Application.Posts.Queries
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public Guid PostId { get; set; }

        public bool IsIncludeAuthor { get; set; }

        public static GetPostByIdQuery Create(Guid id, bool isIncludeAuthor = false)
        {
            return new GetPostByIdQuery
            {
                PostId = id,
                IsIncludeAuthor = isIncludeAuthor
            };
        }
    }
}

using BS.Contracts.PostAggregations;
using MediatR;

namespace BS.Application.Posts.Commands
{
    public class CreatingPostCommand : IRequest<PostDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public AuthorDto? Author { get; set; } = null;

        public static CreatingPostCommand Create(PostDto dto)
        {
            return new CreatingPostCommand
            {
                Title = dto.Title,
                Content = dto.Content,
                Author = dto.Author,
                Description = dto.Description
            };
        }
    }
}

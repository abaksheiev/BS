using BS.Contracts.ApiDtos;

namespace BS.Contracts.PostAggregations
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public AuthorDto? Author { get; set; } = null;
    }
}

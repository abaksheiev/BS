namespace BS.Contracts.ApiDtos
{
    public class PostApiDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public AuthorApiDto? Author { get; set; } = null;
    }
}

using BS.Contracts.ApiDtos;

namespace BS.Contracts.PostAggregations
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

using BS.Contracts.ApiDtos;

namespace BS.Contracts.PostAggregations
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public static AuthorDto? FromAuthorApiDto(AuthorApiDto model) {
            if (model == null) { 
                return default;
            }

            return new AuthorDto{
                Id = model.Id,
                Name = model.Name,  
                Surname = model.Surname
            };
        }
    }
}

using AutoMapper;
using BS.Contracts.PostAggregations;
using BS.Application.Models;
using BS.Application.Posts.Commands;

namespace BS.Application
{
    public class MappingApplicationProfile : Profile
    {
        public MappingApplicationProfile()
        {
            CommandToDTOs();

            PostMapping();

            AuthorMapping();
        }

        /// <summary>
        /// Convert Command to DTOs
        /// </summary>
        private void CommandToDTOs()
        {
            CreateMap<CreatingPostCommand, PostDto>()
                .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(d => d.Author, opt =>
                {
                    opt.MapFrom(src =>
                        src.Author != null
                            ? new Author
                            {
                                Name = src.Author.Name,
                                Surname = src.Author.Surname
                            }
                            : null);
                });
        }

        /// <summary>
        /// Author to AuthorApiDto
        /// AuthorApiDto to Author
        /// </summary>
        private void AuthorMapping()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Surname, opt => opt.MapFrom(src => src.Surname));

            CreateMap<AuthorDto, Author>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Surname, opt => opt.MapFrom(src => src.Surname));
        }

        /// <summary>
        /// Post to PostMapping
        /// PostMapping to Post
        /// </summary>
        private void PostMapping()
        {
            CreateMap<Post, PostDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<PostDto, Post>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                 .ForMember(d => d.Author, opt =>
                 {
                     opt.MapFrom(src =>
                         src.Author != null
                             ? new AuthorDto
                             {
                                 Name = src.Author.Name,
                                 Surname = src.Author.Surname
                             }
                             : null);
                 })
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}

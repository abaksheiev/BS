using AutoMapper;
using BS.Contracts.ApiDtos;
using BS.Contracts.PostAggregations;
using BS.Application.Models;

namespace BS.Init
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            PostMapping();

            AuthorMapping();
        }

        /// <summary>
        /// Author to AuthorApiDto
        /// AuthorApiDto to Author
        /// </summary>
        private void AuthorMapping()
        {
            CreateMap<AuthorDto, AuthorApiDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Surname, opt => opt.MapFrom(src => src.Surname));

            CreateMap<AuthorApiDto, AuthorDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Surname, opt => opt.MapFrom(src => src.Surname));
        }

        /// <summary>
        /// Posts to PostMapping
        /// PostMapping to Posts
        /// </summary>
        private void PostMapping()
        {
            CreateMap<PostDto, PostApiDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<PostApiDto, PostDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
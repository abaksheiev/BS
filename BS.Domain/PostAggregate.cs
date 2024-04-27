using AutoMapper;
using BS.Contracts.PostAggregations;
using BS.Application;
using BS.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BS.Domain
{
    public class PostAggregate : AggregateRoot
    {
        private readonly BlogContext _dbContext;
        private readonly IMapper _mapper;

        public PostAggregate(BlogContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostDto> GetPostById(Guid postId, bool isIncludeAuthor = false)
        {
            var query = _dbContext.Posts.AsQueryable();

            if (isIncludeAuthor)
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

        public async Task<Guid> CreatePostAsync(PostDto postData)
        {
            // Create a new Post
            Post post = new Post
            {
                Title = postData.Title,
                Description = postData.Description,
                Content = postData.Description
            };

            // If authorName is provided, create a new Author and link it to the Post
            if (postData.Author != null)
            {
                Author author = new Author
                {
                    Name = postData.Author.Name,
                    Surname = postData.Author.Surname,
                };

                post.Author = author;
            }

            // Add post (with or without author) to the DbContext
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();

            return post.Id;
        }
    }
}

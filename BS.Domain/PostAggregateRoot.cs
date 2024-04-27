using AutoMapper;
using BS.Application.Models;
using BS.Contracts.Enums;
using BS.Contracts.PostAggregations;
using BS.Contracts.Repositories;

namespace BS.Domain
{
    public class PostAggregateRoot(IPostRepository postRepository, IMapper mapper) : AggregateRoot
    {
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly IPostRepository _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        public Post Post { get; private set; }

        public static PostAggregateRoot Create(IPostRepository categoryRepository, IMapper mapper)
        {
            var aggregateRoot = new PostAggregateRoot(categoryRepository, mapper);
            return aggregateRoot;
        }

        public static PostAggregateRoot Create(PostDto post, IPostRepository categoryRepository, IMapper mapper)
        {
            var aggregateRoot = new PostAggregateRoot(categoryRepository, mapper);
            aggregateRoot.Post = mapper.Map<Post>(post); 
            return aggregateRoot;
        }

        public async Task<PostDto> GetPostById(Guid postId, bool isIncludeAuthor = false)
        {
            var post = await _postRepository.GetByID(postId, isIncludeAuthor ? PostProperties.Author : PostProperties.None);

            if (post == null)
            {
                return default;
            }
            return _mapper.Map<PostDto>(post);
        }

        public void AddAuthor(AuthorDto authorDto)
        {
            // If authorName is provided, create a new Author and link it to the Post
            if (authorDto != null)
            {
                Post.Author = _mapper.Map<Author>(authorDto); ;
            }
        }
        public void Save()
        {
            _postRepository.Save(Post);
        }
    }
}

using BS.Application.Models;
using BS.Contracts.Enums;

namespace BS.Contracts.Repositories
{
    public interface IPostRepository
    {
        Task<Post?> GetByID(Guid id, PostProperties properties = PostProperties.None);

        void Save(Post post);
    }
}

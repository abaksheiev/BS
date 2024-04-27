using BS.Application;
using BS.Application.Models;
using BS.Contracts.Enums;
using BS.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _dbContext;

        public PostRepository(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post?> GetByID(Guid postId, PostProperties properties)
        {
            var query = _dbContext.Posts.AsQueryable();

            if (properties.HasFlag(PostProperties.Author))
            {
                query = query.Include(p => p.Author);
            }

            return await query.FirstOrDefaultAsync(p => p.Id == postId);
        }

        public void Save(Post post)
        {
            // If the category is not already tracked by the context, add it
            if (!_dbContext.Posts.Local.Contains(post))
            {
                _dbContext.Posts.Add(post);
            }

            _dbContext.SaveChanges();
        }
    }
}

using BS.Application.Configurations;
using BS.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BS.Application
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // It is needed only when app works with real database, in another case 
            // there is conflict between InMemory and SqlServer options.
           
            //optionsBuilder.UseSqlServer(@"<CONNECTION STRING>");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfigurations());
            modelBuilder.ApplyConfiguration(new AuthorConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}

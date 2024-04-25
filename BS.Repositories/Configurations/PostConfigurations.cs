using BS.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.Repositories.Configurations
{
    public class PostConfigurations : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts");

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Title)
                .IsRequired();

            builder
                .Property(c => c.Description)
                .IsRequired();

            builder
                .Property(c => c.Content)
                .IsRequired();
        }
    }
}

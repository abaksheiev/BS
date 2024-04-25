using BS.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Application.Configurations
{
    public class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors");

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired();

            builder
                .Property(c => c.Surname)
                .IsRequired();

            // Configure the relationship with Book entity
            builder.HasMany(a => a.Posts)
                   .WithOne(b => b.Author)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: Configure delete behavior

        }
    }
}

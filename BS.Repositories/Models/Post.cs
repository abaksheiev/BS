namespace BS.Application.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public Guid? AuthorId { get; set; } // Required foreign key property
       
        public Author? Author { get; set; } = null; // Required reference navigation to principal
    }
}

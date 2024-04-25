namespace BS.Repositories.Models
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }    

        public string Surname { get; set; }

        public ICollection<Post> Posts { get; } = new List<Post>();
    }
}

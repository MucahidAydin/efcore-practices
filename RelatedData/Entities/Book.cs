namespace RelatedData.Entities
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }
        public int Id { get; set; }
        public string BookName { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
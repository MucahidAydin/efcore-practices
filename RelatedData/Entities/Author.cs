namespace RelatedData.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
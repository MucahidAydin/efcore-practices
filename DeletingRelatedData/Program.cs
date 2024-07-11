using Microsoft.EntityFrameworkCore;

Console.WriteLine();

//mock mock = new();
//await mock.SavingDataAsync();

ApplicationDbContext context = new();

//---
////One to One İlişkisel Senaryolarda Veri Silme
////Persons - Addresses
////Ex: Personeli adresini sil


//Person? person1 = await context.Persons.Include(p => p.Address).FirstOrDefaultAsync(x => x.Id == 1);
//if (person1 != null)
//    context.Addresses.Remove(person1.Address);//One to One
//await context.SaveChangesAsync();


//---
////One to Many İlişkisel Senaryolarda Veri Silme
////Blogs - Posts
////Ex: Bloga ait postları sil
//Blog? blog1 = await context.Blogs.Include(b => b.Posts).FirstOrDefaultAsync(x => x.Id == 1);

//if (blog1 == null)
//    return;

//Post postToRemove = blog1.Posts.FirstOrDefault(x => x.Title == "3. Post");

//if (postToRemove == null)
//    return;

//blog1.Posts.Remove(postToRemove);
//await context.SaveChangesAsync();

//---
//Many to Many İlişkisel Senaryolarda Veri Silme
//Books - Authors
//Ex: Kitaba ait yazarları sil
Book? book = context.Books.Include(b => b.Authors).FirstOrDefault(book => book.Id == 2);

//book1 ile 2.yazarın ilişkisini Cross Table'dan siler.
book.Authors.Remove(book.Authors.FirstOrDefault(a => a.Id == 2));

////Yazarıda silmek istiyorsan kullanabilirsin.
//context.Authors.Remove(book.Authors.FirstOrDefault(a => a.Id == 1));

await context.SaveChangesAsync();



class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Address Address { get; set; }
}
class Address
{
    public int Id { get; set; }
    public string PersonAddress { get; set; }

    public Person Person { get; set; }
}
class Blog
{
    public Blog()
    {
        Posts = new HashSet<Post>();
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}
class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public string Title { get; set; }

    public Blog Blog { get; set; }
}
class Book
{
    public Book()
    {
        Authors = new HashSet<Author>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }

    public ICollection<Author> Authors { get; set; }
}
class Author
{
    public Author()
    {
        Books = new HashSet<Book>();
    }
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<Book> Books { get; set; }
}


class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // UseSqlServer methodu => Database Provider 
        optionsBuilder.UseSqlServer("Server=localhost;Database=application_db;User Id=mucahid;Password=test12345;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Person)
            .WithOne(p => p.Address)
            .HasForeignKey<Address>(a => a.Id);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books);
    }
}



class mock
{
    public static async Task SavingDataAsync()
    {
        ApplicationDbContext context = new();
        Person person = new()
        {
            Name = "Gençay",
            Address = new()
            {
                PersonAddress = "Yenimahalle/ANKARA"
            }
        };

        Person person2 = new()
        {
            Name = "Hilmi"
        };

        await context.AddAsync(person);
        await context.AddAsync(person2);

        Blog blog = new()
        {
            Name = "Gencayyildiz.com Blog",
            Posts = new List<Post>
            {
                new(){ Title = "1. Post" },
                new(){ Title = "2. Post" },
                new(){ Title = "3. Post" },
            }
        };

        await context.Blogs.AddAsync(blog);

        Book book1 = new() { BookName = "1. Kitap" };
        Book book2 = new() { BookName = "2. Kitap" };
        Book book3 = new() { BookName = "3. Kitap" };

        Author author1 = new() { AuthorName = "1. Yazar" };
        Author author2 = new() { AuthorName = "2. Yazar" };
        Author author3 = new() { AuthorName = "3. Yazar" };

        book1.Authors.Add(author1);
        book1.Authors.Add(author2);

        book2.Authors.Add(author1);
        book2.Authors.Add(author2);
        book2.Authors.Add(author3);

        book3.Authors.Add(author3);

        await context.AddAsync(book1);
        await context.AddAsync(book2);
        await context.AddAsync(book3);
        await context.SaveChangesAsync();
    }
}

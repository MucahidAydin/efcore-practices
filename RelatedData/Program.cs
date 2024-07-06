using Microsoft.EntityFrameworkCore;
using RelatedData.Contexts;
using RelatedData.Entities;

Console.WriteLine();

ApplicationDbContext context = new();

//One to One
Person person = new()
{
    Name = "mücahid",
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
await context.SaveChangesAsync();

//One to Many
Blog blog = new()
{
    Name = "mücahid Blog",
    Posts = new List<Post>
    {
        new(){ Title = "1. Post" },
        new(){ Title = "2. Post" },
        new(){ Title = "3. Post" },
    }
};

await context.Blogs.AddAsync(blog);
await context.SaveChangesAsync();

//Many to Many
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

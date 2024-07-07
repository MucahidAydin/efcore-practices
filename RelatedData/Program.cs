using Microsoft.EntityFrameworkCore;
using RelatedData.Contexts;
using RelatedData.Entities;

Console.WriteLine();
ApplicationDbContext context = new();

////One to One
//Person person = new()
//{
//    Name = "mücahid",
//    Address = new()
//    {
//        PersonAddress = "Yenimahalle/ANKARA"
//    }
//};

//Person person2 = new()
//{
//    Name = "Hilmi"
//};

//await context.AddAsync(person);
//await context.AddAsync(person2);
//await context.SaveChangesAsync();

////One to Many
//Blog blog = new()
//{
//    Name = "mücahid Blog",
//    Posts = new List<Post>
//    {
//        new(){ Title = "1. Post" },
//        new(){ Title = "2. Post" },
//        new(){ Title = "3. Post" },
//    }
//};

//await context.Blogs.AddAsync(blog);
//await context.SaveChangesAsync();

////Many to Many
//Book book1 = new() { BookName = "1. Kitap" };
//Book book2 = new() { BookName = "2. Kitap" };
//Book book3 = new() { BookName = "3. Kitap" };

//Author author1 = new() { AuthorName = "1. Yazar" };
//Author author2 = new() { AuthorName = "2. Yazar" };
//Author author3 = new() { AuthorName = "3. Yazar" };

//book1.Authors.Add(author1);
//book1.Authors.Add(author2);

//book2.Authors.Add(author1);
//book2.Authors.Add(author2);
//book2.Authors.Add(author3);

//book3.Authors.Add(author3);

//await context.AddAsync(book1);
//await context.AddAsync(book2);
//await context.AddAsync(book3);
//await context.SaveChangesAsync();


//-----------------------------
////one to one
////person - address
////Ex: address mücahid'ten hilmi'ye taşı

//Person? person = await context.Persons.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == address.Person.Id);
//context.Addresses.Remove(person.Address);

//Person? hilmi = await context.Persons.Include(x => x.Address).FirstOrDefaultAsync(p => p.Name == "Hilmi");
//context.Addresses.Remove(hilmi.Address);
//Address hilmiAdres = new()
//{
//    PersonAddress = person.Address.PersonAddress,
//    Id = hilmi.Id
//};
//context.Addresses.Add(hilmiAdres);
//await context.SaveChangesAsync();


////Ex: mücahid'e yeni adres ekle
//Person? person1 = await context.Persons.Include(x => x.Address).FirstOrDefaultAsync(x => x.Name == "Hilmi");
//context.Addresses.Remove(person1.Address);
//person1.Address = new()
//{
//    PersonAddress = "Ömerli/Mardin"
//};
//await context.SaveChangesAsync();



////-----------------------------
////One to Many
////Blog - Post
////Ex: Hali hazırdaki bir blogun 1 postunu silip yeni 2 adet post ekle.

//Blog? blog1 = await context.Blogs.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Name == "mücahid Blog");

//foreach (var post in blog1.Posts)
//{
//    if(post.Id==2)
//        context.Posts.Remove(post);
//}
//await context.SaveChangesAsync();

//blog1.Posts.Add(new() { Title = "4. Post" });
//blog1.Posts.Add(new() { Title = "5. Post" });
//await context.SaveChangesAsync();


////One to Many
////Blog - Post
////Ex: Yeni bir blog ekliyin ve "mücahid Blog" bloktaki bir post'u yeni bloga aktar.

//Blog? blog1 = await context.Blogs.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Name == "mücahid Blog");

//Post? postDelete = blog1.Posts.FirstOrDefault(p => p.Title == "5. Post");
//context.Posts.Remove(postDelete);
//await context.SaveChangesAsync();

//Blog newUser = new()
//{
//    Name = "blog2",
//    Posts = new List<Post>()
//    {
//        new Post(){Title=postDelete.Title},
//        new Post(){Title="6.Post"}
//    }
//};
//await context.Blogs.AddAsync(newUser);
//await context.SaveChangesAsync();


////-----------------------------
////Many to Many
////Author - Book
////Ex: 1.kitaba 3.yazarıda ekle şuan 1.kitabı 2 yazarı var.(1 ve 2)

//Book? book1 = await context.Books.FirstOrDefaultAsync(x => x.BookName == "3. Kitap");
//Author? author1 = await context.Authors.FirstOrDefaultAsync(x => x.AuthorName == "1. Yazar");

//book1.Authors.Add(author1);//AuthorBook'a veri ekler
//await context.SaveChangesAsync();


////Many to Many
////Author - Book
////Ex: 3.kitaba 4.yazarı ekle

//Book? book1 = await context.Books.FirstOrDefaultAsync(x => x.BookName == "3. Kitap");

//book1.Authors.Add(new() {

//    AuthorName= "4.yazar",

//});//AuthorBook ve Authors tablosuna veri ekler
//await context.SaveChangesAsync();


////Many to Many
////Author - Book
////Ex: 3.yazarın sadece 1.kitabla ilişkisi olsun şuan (1,2,3).kitaplarıyla ilişkisi var.

//Author? author1 = await context.Authors.Include(x=> x.Books).FirstOrDefaultAsync(x => x.AuthorName == "3. Yazar");

//foreach (var book in author1.Books)
//{
//    if (book.BookName != "1. Kitap")
//    {
//        author1.Books.Remove(book); //ilişki silinir context'ten silsem verilerimde silinirdi. -> context.Books.Remove(book);
//    }
//}
//await context.SaveChangesAsync();


////Many to Many
////Author - Book
////Ex: 2.yazarın 1.kitabla ilişkisi kesip 4.kitabı ekliyerek yeni ilişki oluşturalım.

Author? author1 = await context.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.AuthorName == "2. Yazar");

author1.Books.Remove(author1.Books.FirstOrDefault(x => x.BookName == "1. Kitap"));
await context.SaveChangesAsync();

author1.Books.Add(new() //many to many
{
    BookName= "4.kitap"
});
await context.SaveChangesAsync();


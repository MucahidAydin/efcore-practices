

using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();


var blog1 = context.Blogs.First();
var createdDate = context.Entry(blog1).Property<DateTime>("CreatedDate");
createdDate.CurrentValue = DateTime.Now;

Console.WriteLine($"First Blog Name: {blog1.Name}, Created Date: {createdDate.CurrentValue}");
await context.SaveChangesAsync();

var blogs1 = await context.Blogs.Where(b => EF.Property<DateTime>(b, "CreatedDate").Year > 2000)
                         .OrderByDescending(b => EF.Property<DateTime>(b, "CreatedDate")).ToListAsync();

foreach (Blog blog in blogs1)
{
    Console.WriteLine($"Blog Name: {blog.Name}, Created Date: {context.Entry(blog).Property<DateTime>("CreatedDate").CurrentValue}");
}

class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime LastUpdated { get; set; }

    public Blog Blog { get; set; }
}

class ApplicationDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=application_db2;User Id=mucahid;Password=test12345;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property<DateTime>("CreatedDate");
    }
}
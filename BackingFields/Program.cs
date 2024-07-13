using Microsoft.EntityFrameworkCore;

Console.WriteLine();

class Person1
{
    public int Id { get; set; }

    public string name;

    //expression-bodied properties
    public string Name { get => name.Substring(0, 3); set => name = value.Substring(0, 3); }

    public string Department { get; set; }

}

//Data Annotations
class Person2
{
    public int Id { get; set; }

    public string name;
    [BackingField(nameof(name))]

    public string Name { get; set; }

    public string Department { get; set; }

}

//Fluent API
class Person3
{
    public int Id { get; set; }
    public string name;
    public string Name { get; set; }
    public string Department { get; set; }
}

//Field-Only Properties
class Person4
{
    public int Id { get; set; }
    private string _name;
    public string Department { get; set; }

    public string GetName()
    {
        return this._name;
    }
    public void SetName(string value)
    {
        this._name = value;
    }
}
class BackingFieldDbContext : DbContext
{
    public DbSet<Person1> People1 { get; set; }
    public DbSet<Person2> People2 { get; set; }
    public DbSet<Person3> People3 { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // UseSqlServer methodu => Database Provider 
        optionsBuilder.UseSqlServer("Server=localhost;Database=backing_field_db;User Id=mucahid;Password=test12345;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person3>()
            .Property(p => p.Name)
            .HasField(nameof(Person3.name))
            .UsePropertyAccessMode(PropertyAccessMode.Property);
        //PropertyAccessMode.Field

    }
}

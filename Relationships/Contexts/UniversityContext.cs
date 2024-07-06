using Microsoft.EntityFrameworkCore;
using Relationships.Entities;

namespace Relationships.Contexts
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // UseSqlServer methodu => Database Provider 
            optionsBuilder.UseSqlServer("Server=localhost;Database=UniversityDB;User Id=mucahid;Password=test12345;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //--- One to One Relationship --- (Teacher - Office)
            modelBuilder.Entity<Teacher>()// foreign key olmayan tabloda fluent api kullan
                .HasOne(t => t.Office) //navigation property -> t.Office
                .WithOne(o => o.Teacher)
                .HasForeignKey<Office>(o => o.Id); //foreign key -> Office tablosundaki Id

            //--- One to Many Relationship --- (Teacher - Departments)
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Departments)//navigation property -> Departments
                .WithOne(d => d.Teacher)
                .HasForeignKey(d => d.TeacherId);

            //--- One to Many Relationship --- (Teacher - Courses)
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)//navigation property -> Teacher
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);


            //--- Many to Many Relationship --- (Student - Course)
            modelBuilder.Entity<StudentCourse>() //Composite key
                .HasKey(sc => new { sc.StudentId, sc.CourseId });


            modelBuilder.Entity<StudentCourse>() //one to many -> StudentCourse to Student
            .HasOne(sc => sc.Student)
            .WithMany(S => S.Coruses); //Student'daki navigation property

            modelBuilder.Entity<StudentCourse>() //one to many -> StudentCourse to Course
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students); //Coruse'daki navigation property 

        }
    }
}

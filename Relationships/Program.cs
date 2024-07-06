
using Relationships.Contexts;
using Relationships.Entities;


//Fluent API
UniversityContext db = new UniversityContext();

Teacher teacher = new Teacher
{
    Name = "Ahmet",
};

db.Teachers.Add(teacher);
db.SaveChanges();

Office office = new Office
{
    Id = teacher.Id,
    Number = 101,
};

Department department = new Department
{
    Name = "Bilgisayar Mühendisliği",
    TeacherId = teacher.Id,
};

Course course = new Course
{
    CourseName = "Veri Yapıları",
    TeacherId = teacher.Id,
};

Student student = new Student
{
    Name = "Mehmet",
};

db.Offices.Add(office);
db.Departments.Add(department);
db.Courses.Add(course);
db.Students.Add(student);
db.SaveChanges();

StudentCourse studentCourse = new StudentCourse
{
    StudentId = student.Id,
    CourseId = course.Id,
};

db.StudentCourses.Add(studentCourse);
db.SaveChanges();
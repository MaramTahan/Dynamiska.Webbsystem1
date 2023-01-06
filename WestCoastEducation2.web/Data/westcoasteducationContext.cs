using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Models;
namespace WestCoastEducation2.web.Data;
    public class westcoasteducationContext: DbContext
    {
      public DbSet<Courses> GetcoursesData()
      {
      return Set<Courses>();
      }
      public DbSet<Student> GetStudentData()
      {
      return Set<Student>();
      }

      public DbSet<Teacher> GetTeacherData()
      {
      return Set<Teacher>();
      }

      public westcoasteducationContext(DbContextOptions options) : base(options)
      {
      }
 
    }
    
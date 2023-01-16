
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Models;

namespace WestCoastEducation2.web.Data;

    public class westcoasteducationContext: DbContext
    {
        public DbSet<Courses> coursesData => Set<Courses>();
        public DbSet<Student> studentData => Set<Student>();
        public DbSet<Teacher> teacherData => Set<Teacher>();

public westcoasteducationContext(DbContextOptions options) : base(options){}
    }
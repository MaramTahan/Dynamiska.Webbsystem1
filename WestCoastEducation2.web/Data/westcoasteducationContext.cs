
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Models;
namespace WestCoastEducation2.web.Data;
[Keyless]
    public class westcoasteducationContext: DbContext
    {
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder
        .Entity<Courses>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToView("View_Courses");
                
            });
}
 public DbSet<Courses> coursesData => Set<Courses>();

 public westcoasteducationContext(DbContextOptions options) : base(options)
 {
 }
 
    }
    
using System.Text.Json;
using WestCoastEducation2.web.Models;

namespace WestCoastEducation2.web.Data;

    public static class SeedData
    {
        public static async Task LoadCoursesData(westcoasteducationContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Vill endast ladda data om databasens tabell är tom...
        if (context.GetcoursesData().Any()) return;

        // Läsa in json datat...
        var json = System.IO.File.ReadAllText("WestCoastEducation2.web/Data/json/Courses.json");
        // Konvertera json objekten till en lista av Vehicle objekt...
        var coursesList = JsonSerializer.Deserialize<List<Courses>> 
            (json, options);

        if (coursesList is not null && coursesList.Count > 0)
        {
            await context.GetcoursesData().AddRangeAsync(coursesList);
            await context.SaveChangesAsync();
        }
    }
    //--------------------------------------------------------
    public static async Task LoadStudentData(westcoasteducationContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Vill endast ladda data om databasens tabell är tom...
        if (context.GetStudentData().Any()) return;

        // Läsa in json datat...
        var json = System.IO.File.ReadAllText("WestCoastEducation2.web/Data/json/Student.json");
        // Konvertera json objekten till en lista av Vehicle objekt...
        var studentList = JsonSerializer.Deserialize<List<Student>> 
            (json, options);

        if (studentList is not null && studentList.Count > 0)
        {
            await context.GetStudentData().AddRangeAsync(studentList);
            await context.SaveChangesAsync();
        }
    }
    //------------------------------------------------------

    public static async Task LoadTeacherData(westcoasteducationContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Vill endast ladda data om databasens tabell är tom...
        if (context.GetTeacherData().Any()) return;

        // Läsa in json datat...
        var json = System.IO.File.ReadAllText("WestCoastEducation2.web/Data/json/Teacher.json");
        // Konvertera json objekten till en lista av Vehicle objekt...
        var TeacherList = JsonSerializer.Deserialize<List<Teacher>> 
            (json, options);

        if (TeacherList is not null && TeacherList.Count > 0)
        {
            await context.GetTeacherData().AddRangeAsync(TeacherList);
            await context.SaveChangesAsync();
        }
    }
    }

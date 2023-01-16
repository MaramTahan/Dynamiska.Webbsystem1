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

// Only want to load data if the database table is empty...
        if (context.coursesData.Any()) return;

        // Loading the json data...
        var json = System.IO.File.ReadAllText("Data/json/Courses.json");
// Convert the json objects to a list of Vehicle objects...
        var coursesList = JsonSerializer.Deserialize<List<Courses>> 
            (json, options);

        if (coursesList is not null && coursesList.Count > 0)
        {
            await context.coursesData.AddRangeAsync(coursesList);
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
        
        if (context.studentData.Any()) return;

        var json = System.IO.File.ReadAllText("Data/json/Student.json");
        
        var studentList = JsonSerializer.Deserialize<List<Student>> 
            (json, options);

        if (studentList is not null && studentList.Count > 0)
        {
            await context.studentData.AddRangeAsync(studentList);
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

        if (context.teacherData.Any()) return;

        var json = System.IO.File.ReadAllText("Data/json/Teacher.json");
        
        var teacherList = JsonSerializer.Deserialize<List<Teacher>> 
            (json, options);

        if (teacherList is not null && teacherList.Count > 0)
        {
            await context.teacherData.AddRangeAsync(teacherList);
            await context.SaveChangesAsync();
        }
    }
    }

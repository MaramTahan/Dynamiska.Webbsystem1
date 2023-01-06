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
        if (context.coursesData.Any()) return;

        // Läsa in json datat...
        var json = 
        System.IO.File.ReadAllText("WestCoastEducation2.web/Data/json/Courses.json");
        // Konvertera json objekten till en lista av Vehicle objekt...
        var coursesList = JsonSerializer.Deserialize<List<Courses>> 
            (json, options);

        if (coursesList is not null && coursesList.Count > 0)
        {
            await context.coursesData.AddRangeAsync(coursesList);
            await context.SaveChangesAsync();
        }
    }
    }

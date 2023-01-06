using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestCoastEducation2.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name:"Courses",
                columns: table => new
                {
                    courseNumber = table.Column<string>(type: 
                    "Text", nullable: false),
                    name = table.Column<string>(type: 
                    "Text", nullable: false),
                    teacher = table.Column<string>(type: 
                    "Text", nullable: false),
                    placeStudy = table.Column<string>(type: 
                    "Text", nullable: false),
                    startDate = table.Column<DateTime>(type: 
                    "Date", nullable: false),
                    endDate = table.Column<DateTime>(type: 
                    "Date", nullable: false)
                }
                
                
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

        }
    }
}

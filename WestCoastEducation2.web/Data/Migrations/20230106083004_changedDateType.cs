using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestCoastEducation2.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedDateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name:"Courses1",
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
                    startDate = table.Column<string>(type: 
                    "text", nullable: false),
                    endDate = table.Column<string>(type: 
                    "text", nullable: false)
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropTable(
                name: "Courses1");
        }
    }
}

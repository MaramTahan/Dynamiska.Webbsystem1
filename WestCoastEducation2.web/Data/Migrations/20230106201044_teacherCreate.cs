using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestCoastEducation2.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class teacherCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    firstName = table.Column<string>(type: 
                    "Text", nullable: false),
                    lastName = table.Column<string>(type: 
                    "Text", nullable: false),
                    phoneNumber = table.Column<string>(type: 
                    "Text", nullable: false),
                    emailAddress = table.Column<string>(type: 
                    "Text", nullable: false),
                    address = table.Column<string>(type: 
                    "text", nullable: false),
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacher");

        }
    }
}

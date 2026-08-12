using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_api.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnIdOfcourseina_Enrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCourse",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCourse",
                table: "Enrollment");
        }
    }
}

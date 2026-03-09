using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demoEFapp.Migrations
{
    /// <inheritdoc />
    public partial class editmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photoName",
                table: "Students",
                newName: "PhotoName");

            migrationBuilder.RenameColumn(
                name: "CourseCapicity",
                table: "Courses",
                newName: "CourseCapacity");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoName",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoName",
                table: "Students",
                newName: "photoName");

            migrationBuilder.RenameColumn(
                name: "CourseCapacity",
                table: "Courses",
                newName: "CourseCapicity");

            migrationBuilder.AlterColumn<string>(
                name: "photoName",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}

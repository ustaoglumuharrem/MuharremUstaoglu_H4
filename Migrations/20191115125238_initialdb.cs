using Microsoft.EntityFrameworkCore.Migrations;

namespace HW3.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quota",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseQuota",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseQuota",
                table: "Courses");

            migrationBuilder.AddColumn<long>(
                name: "quota",
                table: "Courses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

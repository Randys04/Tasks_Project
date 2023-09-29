using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tasks_Project.Migrations
{
    public partial class TaskCompletedTaskColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CompletedTask",
                table: "Task",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedTask",
                table: "Task");
        }
    }
}

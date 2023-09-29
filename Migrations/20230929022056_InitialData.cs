using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tasks_Project.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("13e9bff2-1e86-45b2-8a62-bb932992c723"), null, "Personal Activities", 25 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("13e9bff2-1e86-45b2-8a62-bb932992c7bd"), null, "Univesrity homeworks to do", 30 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CompletedTask", "CreationDate", "Description", "TaskPriority", "Title" },
                values: new object[] { new Guid("13e9bff2-1e86-45b2-8a62-bb932992c602"), new Guid("13e9bff2-1e86-45b2-8a62-bb932992c723"), false, new DateTime(2023, 9, 28, 20, 20, 55, 945, DateTimeKind.Local).AddTicks(5557), null, 2, "Prepare a presentation" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CompletedTask", "CreationDate", "Description", "TaskPriority", "Title" },
                values: new object[] { new Guid("13e9bff2-1e86-45b2-8a62-bb932992c675"), new Guid("13e9bff2-1e86-45b2-8a62-bb932992c7bd"), false, new DateTime(2023, 9, 28, 20, 20, 55, 945, DateTimeKind.Local).AddTicks(5539), null, 0, "IO homewework 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("13e9bff2-1e86-45b2-8a62-bb932992c602"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("13e9bff2-1e86-45b2-8a62-bb932992c675"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("13e9bff2-1e86-45b2-8a62-bb932992c723"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("13e9bff2-1e86-45b2-8a62-bb932992c7bd"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

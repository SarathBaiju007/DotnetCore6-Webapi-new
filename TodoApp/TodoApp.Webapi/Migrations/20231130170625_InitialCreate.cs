using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Webapi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[] { new Guid("2f91cb78-313d-4def-b795-2c3ea982ff3d"), new DateTime(2023, 11, 30, 22, 36, 25, 714, DateTimeKind.Local).AddTicks(4507), false, "Cooking", null });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[] { new Guid("47e174d8-1350-4a00-bd49-d8b1fc5bf1d0"), new DateTime(2023, 11, 30, 22, 36, 25, 714, DateTimeKind.Local).AddTicks(4490), false, "Excercise", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}

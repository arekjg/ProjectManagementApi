using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class pmDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimePassed = table.Column<TimeSpan>(type: "time", nullable: true),
                    WorkTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimePassed = table.Column<TimeSpan>(type: "time", nullable: true),
                    WorkTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Created", "CreatedById", "Deadline", "Description", "Ended", "LastEdited", "Name", "Priority", "ProjectId", "Status", "TimePassed", "WorkTime" },
                values: new object[] { 1, new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2515), 2, new DateTime(2023, 12, 29, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2531), "Build a pod for the rocket to start", null, new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2525), "Build a starting pod", 3, 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Created", "CreatedById", "Deadline", "Description", "Ended", "LastEdited", "Name", "Priority", "Status", "TimePassed", "WorkTime" },
                values: new object[] { 1, new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2428), 2, new DateTime(2024, 3, 18, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2451), "Building a spaceship that will get us to Mars", null, new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2443), "Spaceship to Mars", 2, 0, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Created", "FirstName", "LastEdited", "LastName", "Login", "Password", "SupervisorId", "UserType" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2030), "Rick", new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2087), "Sanchez", "sancheezium", "1234", null, 0 },
                    { 2, "", new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2098), "Morty", new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2105), "Smith", "morty", "1234", null, 1 },
                    { 3, "", new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2113), "Summer", new DateTime(2023, 12, 9, 23, 9, 7, 940, DateTimeKind.Local).AddTicks(2120), "Smith", "sumsum", "1234", null, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

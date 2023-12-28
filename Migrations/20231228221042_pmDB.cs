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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtDate = table.Column<int>(type: "int", nullable: false),
                    LastEdited = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    CreatedAtDate = table.Column<int>(type: "int", nullable: false),
                    LastEdited = table.Column<int>(type: "int", nullable: false),
                    EndedAtDate = table.Column<int>(type: "int", nullable: true),
                    DeadlineDate = table.Column<int>(type: "int", nullable: false),
                    TimePassed = table.Column<int>(type: "int", nullable: true),
                    WorkTime = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    CreatedAtDate = table.Column<int>(type: "int", nullable: false),
                    LastEdited = table.Column<int>(type: "int", nullable: false),
                    EndedAtDate = table.Column<int>(type: "int", nullable: true),
                    DeadlineDate = table.Column<int>(type: "int", nullable: false),
                    TimePassed = table.Column<int>(type: "int", nullable: true),
                    WorkTime = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "CreatedAtDate", "FirstName", "LastEdited", "LastName", "Login", "Password", "SupervisorId", "UserType" },
                values: new object[,]
                {
                    { 1, "", 81449, "Rick", 81449, "Sanchez", "sancheezium", "1234", null, 0 },
                    { 2, "", 81449, "Morty", 81449, "Smith", "morty", "1234", null, 1 },
                    { 3, "", 81449, "Summer", 81449, "Smith", "sumsum", "1234", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAtDate", "CreatedById", "DeadlineDate", "Description", "EndedAtDate", "LastEdited", "Name", "Priority", "Status", "TimePassed", "WorkTime" },
                values: new object[] { 1, 81449, 2, 81549, "Building a spaceship that will get us to Mars", null, 81449, "Spaceship to Mars", 2, 0, null, null });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedAtDate", "CreatedById", "DeadlineDate", "Description", "EndedAtDate", "LastEdited", "Name", "Priority", "ProjectId", "Status", "TimePassed", "WorkTime" },
                values: new object[] { 1, 81449, 2, 81469, "Build a pod for the rocket to start", null, 81449, "Build a starting pod", 3, 1, 0, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CreatedById",
                table: "Jobs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectId",
                table: "Jobs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedById",
                table: "Projects",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SupervisorId",
                table: "Users",
                column: "SupervisorId");
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

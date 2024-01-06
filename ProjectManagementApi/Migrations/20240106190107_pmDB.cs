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

            migrationBuilder.CreateTable(
                name: "JobEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    StartedAtDate = table.Column<int>(type: "int", nullable: false),
                    StartedAtTime = table.Column<int>(type: "int", nullable: false),
                    EndedAtDate = table.Column<int>(type: "int", nullable: true),
                    EndedAtTime = table.Column<int>(type: "int", nullable: true),
                    TimePassed = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobEntries_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "CreatedAtDate", "FirstName", "LastEdited", "LastName", "Login", "Password", "SupervisorId", "UserType" },
                values: new object[,]
                {
                    { 1, "", 81458, "Rick", 81458, "Sanchez", "sancheezium", "1234", null, 0 },
                    { 2, "", 81458, "Morty", 81458, "Smith", "morty", "1234", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAtDate", "CreatedById", "DeadlineDate", "Description", "EndedAtDate", "LastEdited", "Name", "Priority", "Status", "TimePassed", "WorkTime" },
                values: new object[] { 1, 81458, 2, 81558, "Building a spaceship that will get us to Mars", null, 81458, "Spaceship to Mars", 2, 0, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "CreatedAtDate", "FirstName", "LastEdited", "LastName", "Login", "Password", "SupervisorId", "UserType" },
                values: new object[,]
                {
                    { 3, "", 81458, "Summer", 81458, "Smith", "sumsum", "1234", 2, 2 },
                    { 4, "", 81458, "Bird", 81458, "Person", "bird_person", "birb", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedAtDate", "CreatedById", "DeadlineDate", "Description", "EndedAtDate", "LastEdited", "Name", "Priority", "ProjectId", "Status", "TimePassed", "WorkTime" },
                values: new object[,]
                {
                    { 1, 81458, 2, 81478, "Build a pod for the rocket to start", null, 81458, "Build a starting pod", 3, 1, 0, null, null },
                    { 2, 81458, 2, 81493, "Build a rocket to take the shuttle outside the atmosphere", null, 81458, "Build a rocket", 2, 1, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "JobEntries",
                columns: new[] { "Id", "EndedAtDate", "EndedAtTime", "JobId", "StartedAtDate", "StartedAtTime", "TimePassed", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, 1, 81458, 7206727, null, 3 },
                    { 2, null, null, 2, 81458, 7206727, null, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobEntries_JobId",
                table: "JobEntries",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEntries_UserId",
                table: "JobEntries",
                column: "UserId");

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
                name: "JobEntries");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

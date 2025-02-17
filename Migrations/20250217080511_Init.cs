using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerCompanyId = table.Column<int>(type: "int", nullable: false),
                    ExecutorCompanyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CustomerCompanyId",
                        column: x => x.CustomerCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Companies_ExecutorCompanyId",
                        column: x => x.ExecutorCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeId",
                table: "ProjectEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_ProjectId",
                table: "ProjectEmployees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerCompanyId",
                table: "Projects",
                column: "CustomerCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ExecutorCompanyId",
                table: "Projects",
                column: "ExecutorCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.InsertData(
        table: "Companies",
        columns: new[] { "Id", "Name" },
        values: new object[,]
        {
            { 1, "TechCorp" },
            { 2, "Innovate Ltd" },
            { 3, "SoftSolutions" },
            { 4, "DevHouse" },
            { 5, "AI Works" }
        });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName", "Email", "CompanyId" },
                values: new object[,]
                {
            { 1, "John", "Doe", "A", "john.doe@techcorp.com", 1 },
            { 2, "Jane", "Smith", "B", "jane.smith@innovate.com", 2 },
            { 3, "Alice", "Johnson", "C", "alice.j@softsolutions.com", 3 },
            { 4, "Bob", "Brown", "D", "bob.b@devhouse.com", 4 },
            { 5, "Charlie", "Davis", "E", "charlie.d@aiworks.com", 5 },
            { 6, "Dave", "Wilson", "F", "dave.w@techcorp.com", 1 },
            { 7, "Eva", "Anderson", "G", "eva.a@innovate.com", 2 },
            { 8, "Frank", "Thomas", "H", "frank.t@softsolutions.com", 3 },
            { 9, "Grace", "Lee", "I", "grace.l@devhouse.com", 4 },
            { 10, "Henry", "White", "J", "henry.w@aiworks.com", 5 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ProjectName", "CustomerCompanyId", "ExecutorCompanyId", "StartDate", "Priority", "ProjectManagerId" },
                values: new object[,]
                {
            { 1, "Project Alpha", 1, 2, DateTime.UtcNow, 1, 1 },
            { 2, "Project Beta", 2, 3, DateTime.UtcNow, 2, 2 },
            { 3, "Project Gamma", 3, 4, DateTime.UtcNow, 3, 3 },
            { 4, "Project Delta", 4, 5, DateTime.UtcNow, 1, 4 },
            { 5, "Project Epsilon", 5, 1, DateTime.UtcNow, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "Id", "ProjectId", "EmployeeId" },
                values: new object[,]
                {
            { 1, 1, 2 }, { 2, 1, 3 }, { 3, 1, 4 },
            { 4, 2, 5 }, { 5, 2, 6 }, { 6, 2, 7 },
            { 7, 3, 8 }, { 8, 3, 9 }, { 9, 3, 10 },
            { 10, 4, 1 }, { 11, 4, 3 }, { 12, 4, 5 },
            { 13, 5, 7 }, { 14, 5, 9 }, { 15, 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEmployees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

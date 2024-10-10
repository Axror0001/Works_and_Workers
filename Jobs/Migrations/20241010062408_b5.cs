using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobs.Migrations
{
    /// <inheritdoc />
    public partial class b5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_jobs_CompanyId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_levels_LevelId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_CompanyId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_LevelId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "levels");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "jobs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "levels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "jobs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_CompanyId",
                table: "employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_LevelId",
                table: "employees",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_jobs_CompanyId",
                table: "employees",
                column: "CompanyId",
                principalTable: "jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_levels_LevelId",
                table: "employees",
                column: "LevelId",
                principalTable: "levels",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.Data.Migrations
{
    /// <inheritdoc />
    public partial class one3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Employees_employeeId",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "Roles",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_employeeId",
                table: "Roles",
                newName: "IX_Roles_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Employees_EmployeeId",
                table: "Roles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Employees_EmployeeId",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Roles",
                newName: "employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_EmployeeId",
                table: "Roles",
                newName: "IX_Roles_employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Employees_employeeId",
                table: "Roles",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

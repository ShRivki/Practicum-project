using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.Data.Migrations
{
    /// <inheritdoc />
    public partial class one1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "employeeId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Employees_employeeId",
                table: "Roles",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Employees_employeeId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "Roles",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_employeeId",
                table: "Roles",
                newName: "IX_Roles_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Roles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Employees_EmployeeId",
                table: "Roles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Carbon.Migrations
{
    public partial class removeemployeedependency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_Employees_EmployeeId",
                table: "Dependents");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Dependents",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_Employees_EmployeeId",
                table: "Dependents",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_Employees_EmployeeId",
                table: "Dependents");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Dependents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_Employees_EmployeeId",
                table: "Dependents",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

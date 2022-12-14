using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaryManagementApp.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BonusAddedNetSalary",
                table: "Employees",
                newName: "Bonus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bonus",
                table: "Employees",
                newName: "BonusAddedNetSalary");
        }
    }
}

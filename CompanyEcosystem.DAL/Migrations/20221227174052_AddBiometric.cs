using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEcosystem.DAL.Migrations
{
    public partial class AddBiometric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FingerprintData",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetinaScanData",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FingerprintData",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RetinaScanData",
                table: "Employees");
        }
    }
}

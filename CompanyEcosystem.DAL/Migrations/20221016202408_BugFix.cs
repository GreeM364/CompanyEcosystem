using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEcosystem.DAL.Migrations
{
    public partial class BugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThingsId",
                table: "PhotoThings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThingsId",
                table: "PhotoThings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

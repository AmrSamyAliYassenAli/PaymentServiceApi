using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentServices.DataAccess.Migrations
{
    public partial class changesincompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "businessType",
                schema: "Subscription",
                table: "CompanyProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sectorId",
                schema: "Subscription",
                table: "CompanyProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "businessType",
                schema: "Subscription",
                table: "CompanyProfile");

            migrationBuilder.DropColumn(
                name: "sectorId",
                schema: "Subscription",
                table: "CompanyProfile");
        }
    }
}

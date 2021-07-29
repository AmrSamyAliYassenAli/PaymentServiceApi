using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentServices.DataAccess.Migrations
{
    public partial class changesincompanycntactinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "contactEmail",
                schema: "Subscription",
                table: "CompanyProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contactName",
                schema: "Subscription",
                table: "CompanyProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contactPhone",
                schema: "Subscription",
                table: "CompanyProfile",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contactEmail",
                schema: "Subscription",
                table: "CompanyProfile");

            migrationBuilder.DropColumn(
                name: "contactName",
                schema: "Subscription",
                table: "CompanyProfile");

            migrationBuilder.DropColumn(
                name: "contactPhone",
                schema: "Subscription",
                table: "CompanyProfile");
        }
    }
}

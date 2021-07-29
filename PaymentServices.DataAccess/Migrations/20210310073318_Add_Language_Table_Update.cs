using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentServices.DataAccess.Migrations
{
    public partial class Add_Language_Table_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISOcode",
                schema: "Lookup",
                table: "Language",
                newName: "isoCode");

            migrationBuilder.RenameColumn(
                name: "Languageid",
                schema: "Lookup",
                table: "Language",
                newName: "languageid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isoCode",
                schema: "Lookup",
                table: "Language",
                newName: "ISOcode");

            migrationBuilder.RenameColumn(
                name: "languageid",
                schema: "Lookup",
                table: "Language",
                newName: "Languageid");
        }
    }
}

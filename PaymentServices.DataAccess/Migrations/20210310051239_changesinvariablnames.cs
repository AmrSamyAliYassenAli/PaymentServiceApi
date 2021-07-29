using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentServices.DataAccess.Migrations
{
    public partial class changesinvariablnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Lookup",
                table: "Language",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                schema: "Lookup",
                table: "Language",
                newName: "Name");
        }
    }
}

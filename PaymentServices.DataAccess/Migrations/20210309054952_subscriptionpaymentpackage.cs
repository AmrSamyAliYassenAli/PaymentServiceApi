using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentServices.DataAccess.Migrations
{
    public partial class subscriptionpaymentpackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Subscription");

            migrationBuilder.EnsureSchema(
                name: "Packages");

            migrationBuilder.CreateTable(
                name: "AccessRoles",
                schema: "Subscription",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accessType = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRoles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPackages",
                schema: "Packages",
                columns: table => new
                {
                    packageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noOfUsers = table.Column<int>(type: "int", nullable: false),
                    noOfBranches = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPackages", x => x.packageId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionTransaction",
                schema: "Subscription",
                columns: table => new
                {
                    subscriptionTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    subscriptionId = table.Column<int>(type: "int", nullable: false),
                    packagePriceId = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPaid = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionTransaction", x => x.subscriptionTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "AccessPermissions",
                schema: "Subscription",
                columns: table => new
                {
                    permissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    configId = table.Column<int>(type: "int", nullable: false),
                    actionId = table.Column<int>(type: "int", nullable: false),
                    isPolicy = table.Column<bool>(type: "bit", nullable: false),
                    isAllowed = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPermissions", x => x.permissionId);
                    table.ForeignKey(
                        name: "FK_AccessPermissions_AccessRoles_roleId",
                        column: x => x.roleId,
                        principalSchema: "Subscription",
                        principalTable: "AccessRoles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfile",
                schema: "Subscription",
                columns: table => new
                {
                    companyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    languageId = table.Column<int>(type: "int", nullable: false),
                    slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneCountry = table.Column<int>(type: "int", nullable: false),
                    fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    faxCountry = table.Column<int>(type: "int", nullable: false),
                    packageId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isVerificationNeeded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfile", x => x.companyId);
                    table.ForeignKey(
                        name: "FK_CompanyProfile_SubscriptionPackages_packageId",
                        column: x => x.packageId,
                        principalSchema: "Packages",
                        principalTable: "SubscriptionPackages",
                        principalColumn: "packageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPackagePrices",
                schema: "Packages",
                columns: table => new
                {
                    packagePriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    packageId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: false),
                    isMonthly = table.Column<bool>(type: "bit", nullable: false),
                    isYearly = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPackagePrices", x => x.packagePriceId);
                    table.ForeignKey(
                        name: "FK_SubscriptionPackagePrices_Country_countryId",
                        column: x => x.countryId,
                        principalSchema: "Lookup",
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionPackagePrices_SubscriptionPackages_packageId",
                        column: x => x.packageId,
                        principalSchema: "Packages",
                        principalTable: "SubscriptionPackages",
                        principalColumn: "packageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                schema: "Subscription",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salutationId = table.Column<int>(type: "int", nullable: false),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.userId);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_AccessRoles_roleId",
                        column: x => x.roleId,
                        principalSchema: "Subscription",
                        principalTable: "AccessRoles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_CompanyProfile_companyId",
                        column: x => x.companyId,
                        principalSchema: "Subscription",
                        principalTable: "CompanyProfile",
                        principalColumn: "companyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessPermissions_roleId",
                schema: "Subscription",
                table: "AccessPermissions",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfile_packageId",
                schema: "Subscription",
                table: "CompanyProfile",
                column: "packageId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_companyId",
                schema: "Subscription",
                table: "CompanyUsers",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_roleId",
                schema: "Subscription",
                table: "CompanyUsers",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPackagePrices_countryId",
                schema: "Packages",
                table: "SubscriptionPackagePrices",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPackagePrices_packageId",
                schema: "Packages",
                table: "SubscriptionPackagePrices",
                column: "packageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessPermissions",
                schema: "Subscription");

            migrationBuilder.DropTable(
                name: "CompanyUsers",
                schema: "Subscription");

            migrationBuilder.DropTable(
                name: "SubscriptionPackagePrices",
                schema: "Packages");

            migrationBuilder.DropTable(
                name: "SubscriptionTransaction",
                schema: "Subscription");

            migrationBuilder.DropTable(
                name: "AccessRoles",
                schema: "Subscription");

            migrationBuilder.DropTable(
                name: "CompanyProfile",
                schema: "Subscription");

            migrationBuilder.DropTable(
                name: "SubscriptionPackages",
                schema: "Packages");
        }
    }
}

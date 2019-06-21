using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoraAPF.org.Data.Migrations
{
    public partial class AddTables_BillingAndPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(maxLength: 200, nullable: false),
                    Address2 = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 80, nullable: false),
                    State = table.Column<string>(maxLength: 80, nullable: false),
                    Country = table.Column<string>(maxLength: 25, nullable: false),
                    Phone = table.Column<string>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 30, nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillingId = table.Column<int>(nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TransactionId = table.Column<string>(maxLength: 100, nullable: false),
                    AuthCode = table.Column<string>(maxLength: 100, nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    CardF4L4 = table.Column<string>(maxLength: 12, nullable: false),
                    CardHolderName = table.Column<string>(maxLength: 100, nullable: false),
                    CardToken = table.Column<string>(maxLength: 200, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_BillingInfo",
                        column: x => x.BillingId,
                        principalTable: "BillingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitorLog_LocationIP_VisitedOn",
                table: "VisitorLog",
                columns: new[] { "LocationIP", "VisitedOn" });

            migrationBuilder.CreateIndex(
                name: "IX_BillingInfo_FirstName",
                table: "BillingInfo",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInfo_LastName",
                table: "BillingInfo",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BillingId",
                table: "Payment",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CurrencyId",
                table: "Payment",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentDate",
                table: "Payment",
                column: "PaymentDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "BillingInfo");

            migrationBuilder.DropIndex(
                name: "IX_VisitorLog_LocationIP_VisitedOn",
                table: "VisitorLog");
        }
    }
}

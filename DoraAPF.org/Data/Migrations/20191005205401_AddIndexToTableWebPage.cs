using Microsoft.EntityFrameworkCore.Migrations;

namespace DoraAPF.org.Data.Migrations
{
    public partial class AddIndexToTableWebPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WebPage_WebPageTypeId",
                table: "WebPage",
                column: "WebPageTypeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WebPage_WebPageTypeId",
                table: "WebPage");
        }
    }
}

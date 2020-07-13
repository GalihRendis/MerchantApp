using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchantApp.Migrations
{
    public partial class AddImageAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_content",
                table: "Offers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_content",
                table: "Offers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchantApp.Migrations
{
    public partial class AddFanRuleMinReferralColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fan_rule_min_referral",
                table: "Offers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fan_rule_min_referral",
                table: "Offers");
        }
    }
}

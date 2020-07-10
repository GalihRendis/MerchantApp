using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchantApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    official_url = table.Column<string>(nullable: true),
                    sender_email = table.Column<string>(nullable: true),
                    subdomain = table.Column<string>(nullable: true),
                    industry_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OfferCategories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    expired_at = table.Column<DateTime>(nullable: false),
                    friend_reward_type = table.Column<int>(nullable: false),
                    friend_reward_label = table.Column<string>(nullable: true),
                    friend_reward_discount = table.Column<int>(nullable: false),
                    friend_reward_discount_is_percent = table.Column<bool>(nullable: false),
                    friend_reward_expired_at = table.Column<DateTime>(nullable: false),
                    fan_reward_type = table.Column<int>(nullable: false),
                    fan_reward_label = table.Column<string>(nullable: true),
                    fan_reward_amount = table.Column<int>(nullable: false),
                    fan_reward_amount_is_percent = table.Column<bool>(nullable: false),
                    fan_rule_min_referral = table.Column<int>(nullable: false),
                    fan_rule_min_friend_referral = table.Column<int>(nullable: false),
                    merchant_id = table.Column<int>(nullable: false),
                    offer_category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Offers_Merchants_merchant_id",
                        column: x => x.merchant_id,
                        principalTable: "Merchants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_OfferCategories_offer_category_id",
                        column: x => x.offer_category_id,
                        principalTable: "OfferCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_merchant_id",
                table: "Offers",
                column: "merchant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_offer_category_id",
                table: "Offers",
                column: "offer_category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "OfferCategories");
        }
    }
}

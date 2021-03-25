using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristiqueDbContext.Migrations
{
    public partial class addedRestaurantfkToHotelandSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Sites",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Hotels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sites_RestaurantId",
                table: "Sites",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_RestaurantId",
                table: "Hotels",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Restaurants_RestaurantId",
                table: "Hotels",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Restaurants_RestaurantId",
                table: "Sites",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Restaurants_RestaurantId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Restaurants_RestaurantId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Sites_RestaurantId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_RestaurantId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Hotels");
        }
    }
}

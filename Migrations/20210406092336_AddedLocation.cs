using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristiqueDbContext.Migrations
{
    public partial class AddedLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Sites",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Hotels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Pays = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sites_LocationId",
                table: "Sites",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_LocationId",
                table: "Restaurants",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LocationId",
                table: "Hotels",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Location_LocationId",
                table: "Hotels",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Location_LocationId",
                table: "Restaurants",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Location_LocationId",
                table: "Sites",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Location_LocationId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Location_LocationId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Location_LocationId",
                table: "Sites");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Sites_LocationId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_LocationId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_LocationId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Hotels");
        }
    }
}

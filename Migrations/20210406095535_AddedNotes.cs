using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristiqueDbContext.Migrations
{
    public partial class AddedNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NoteHotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Etoile = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteHotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NoteHotels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoteRestaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Etoile = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteRestaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteRestaurants_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NoteRestaurants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoteSites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Etoile = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteSites_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NoteSites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteHotels_HotelId",
                table: "NoteHotels",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteHotels_UserId",
                table: "NoteHotels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteRestaurants_RestaurantId",
                table: "NoteRestaurants",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteRestaurants_UserId",
                table: "NoteRestaurants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteSites_SiteId",
                table: "NoteSites",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteSites_UserId",
                table: "NoteSites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Locations_LocationId",
                table: "Restaurants",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Locations_LocationId",
                table: "Sites",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Locations_LocationId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Locations_LocationId",
                table: "Sites");

            migrationBuilder.DropTable(
                name: "NoteHotels");

            migrationBuilder.DropTable(
                name: "NoteRestaurants");

            migrationBuilder.DropTable(
                name: "NoteSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristiqueDbContext.Migrations
{
    public partial class addedCommentsToRestoandSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestaurantComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    RestaurantCommentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantComments_RestaurantComments_RestaurantCommentId",
                        column: x => x.RestaurantCommentId,
                        principalTable: "RestaurantComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantComments_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiteComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    SitesCommentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteComments_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteComments_SiteComments_SitesCommentId",
                        column: x => x.SitesCommentId,
                        principalTable: "SiteComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantComments_RestaurantCommentId",
                table: "RestaurantComments",
                column: "RestaurantCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantComments_RestaurantId",
                table: "RestaurantComments",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantComments_UserId",
                table: "RestaurantComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteComments_SiteId",
                table: "SiteComments",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteComments_SitesCommentId",
                table: "SiteComments",
                column: "SitesCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteComments_UserId",
                table: "SiteComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantComments");

            migrationBuilder.DropTable(
                name: "SiteComments");
        }
    }
}

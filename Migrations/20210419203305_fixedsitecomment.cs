using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristiqueDbContext.Migrations
{
    public partial class fixedsitecomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteComments_SiteComments_SitesCommentId",
                table: "SiteComments");

            migrationBuilder.DropIndex(
                name: "IX_SiteComments_SitesCommentId",
                table: "SiteComments");

            migrationBuilder.DropColumn(
                name: "SitesCommentId",
                table: "SiteComments");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "SiteComments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "SiteComments");

            migrationBuilder.AddColumn<int>(
                name: "SitesCommentId",
                table: "SiteComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiteComments_SitesCommentId",
                table: "SiteComments",
                column: "SitesCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteComments_SiteComments_SitesCommentId",
                table: "SiteComments",
                column: "SitesCommentId",
                principalTable: "SiteComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

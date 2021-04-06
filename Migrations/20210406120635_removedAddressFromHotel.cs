using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristiqueDbContext.Migrations
{
    public partial class removedAddressFromHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Hotels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElegantStore.Infrastructure.Migrations
{
    public partial class UpdateCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CartItems");
        }
    }
}

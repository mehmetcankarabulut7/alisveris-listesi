using Microsoft.EntityFrameworkCore.Migrations;

namespace Bitirme_Proje.Migrations
{
    public partial class onShoppingpropertyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnShopping",
                table: "ShoppingLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnShopping",
                table: "ShoppingLists");
        }
    }
}

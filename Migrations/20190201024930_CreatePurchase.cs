using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_course.Migrations
{
    public partial class CreatePurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "UnityPrice");

            migrationBuilder.AddColumn<string>(
                name: "Unity",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unity",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "UnityPrice",
                table: "Product",
                newName: "Price");
        }
    }
}

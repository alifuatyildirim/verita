using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verita.Data.Migrations
{
    public partial class categorymainimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Categories");
        }
    }
}

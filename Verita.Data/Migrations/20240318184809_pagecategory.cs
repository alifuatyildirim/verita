using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verita.Data.Migrations
{
    public partial class pagecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageCategory",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageCategory",
                table: "Pages");
        }
    }
}

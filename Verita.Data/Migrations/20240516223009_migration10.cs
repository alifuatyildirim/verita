using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verita.Data.Migrations
{
    public partial class migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeyveliRehberType",
                table: "MeyveliRehber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeyveliRehberType",
                table: "MeyveliRehber",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

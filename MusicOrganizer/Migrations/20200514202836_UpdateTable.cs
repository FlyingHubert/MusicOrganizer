using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicOrganizer.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Komponist",
                table: "Songs",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Komponist",
                table: "Songs");
        }
    }
}

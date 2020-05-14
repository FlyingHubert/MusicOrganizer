using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicOrganizer.Migrations
{
    public partial class NewTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Interpret = table.Column<string>(maxLength: 100, nullable: true),
                    Album = table.Column<string>(maxLength: 100, nullable: true),
                    LP = table.Column<int>(nullable: false),
                    single = table.Column<int>(nullable: false),
                    Art = table.Column<string>(nullable: true),
                    CD = table.Column<int>(nullable: false),
                    Jahr = table.Column<int>(nullable: false),
                    Bemerkungen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}

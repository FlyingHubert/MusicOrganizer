using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicOrganizer.Migrations
{
    public partial class CreateNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Interpret = table.Column<string>(maxLength: 200, nullable: true),
                    Album = table.Column<string>(maxLength: 200, nullable: true),
                    LP = table.Column<int>(nullable: true),
                    single = table.Column<int>(nullable: true),
                    Art = table.Column<string>(nullable: true),
                    CD = table.Column<int>(nullable: true),
                    Jahr = table.Column<int>(nullable: true),
                    Komponist = table.Column<string>(maxLength: 200, nullable: true),
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

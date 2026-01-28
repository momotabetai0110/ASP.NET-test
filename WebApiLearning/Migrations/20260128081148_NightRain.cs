using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLearning.Migrations
{
    /// <inheritdoc />
    public partial class NightRain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NightRains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bosses = table.Column<int>(type: "INTEGER", nullable: false),
                    TerrainEffect = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NightRains", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NightRains");
        }
    }
}

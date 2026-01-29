using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLearning.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TerrainEffect",
                table: "NightRains",
                newName: "TerrainEffectId");

            migrationBuilder.RenameColumn(
                name: "Bosses",
                table: "NightRains",
                newName: "IsEver");

            migrationBuilder.AddColumn<int>(
                name: "BossesId",
                table: "NightRains",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BossesId",
                table: "NightRains");

            migrationBuilder.RenameColumn(
                name: "TerrainEffectId",
                table: "NightRains",
                newName: "TerrainEffect");

            migrationBuilder.RenameColumn(
                name: "IsEver",
                table: "NightRains",
                newName: "Bosses");
        }
    }
}

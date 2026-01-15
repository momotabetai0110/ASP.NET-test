using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLearning.Migrations
{
    /// <inheritdoc />
    public partial class AddFaceLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaceLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<bool>(type: "INTEGER", nullable: false),
                    Job = table.Column<string>(type: "TEXT", nullable: false),
                    EarlySociable = table.Column<int>(type: "INTEGER", nullable: false),
                    MidSociable = table.Column<int>(type: "INTEGER", nullable: false),
                    LateSociable = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaceLogs");
        }
    }
}

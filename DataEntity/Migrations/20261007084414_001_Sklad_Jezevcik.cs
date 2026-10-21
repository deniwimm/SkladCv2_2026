using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntity.Migrations
{
    /// <inheritdoc />
    public partial class _001_Sklad_Jezevcik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MernaJednotka",
                columns: table => new
                {
                    MernaJednotkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Popis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MernaJednotka", x => x.MernaJednotkaId);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazev = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MnozPoj = table.Column<int>(type: "int", nullable: false),
                    MnozDoPal = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "date", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MernaJednotkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_MernaJednotka_MernaJednotkaId",
                        column: x => x.MernaJednotkaId,
                        principalTable: "MernaJednotka",
                        principalColumn: "MernaJednotkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_MernaJednotkaId",
                table: "Material",
                column: "MernaJednotkaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "MernaJednotka");
        }
    }
}

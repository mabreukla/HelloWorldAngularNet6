using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloWorldAngularNet6.Migrations
{
    public partial class FluentApiToUniverse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Universe",
                table: "Heroes",
                newName: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_UniverseId",
                table: "Heroes",
                column: "UniverseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Universes_UniverseId",
                table: "Heroes",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Universes_UniverseId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_UniverseId",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "UniverseId",
                table: "Heroes",
                newName: "Universe");
        }
    }
}

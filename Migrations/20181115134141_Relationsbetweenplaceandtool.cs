using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolMvc.Migrations
{
    public partial class Relationsbetweenplaceandtool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceID",
                table: "Tools",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tools_PlaceID",
                table: "Tools",
                column: "PlaceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Places_PlaceID",
                table: "Tools",
                column: "PlaceID",
                principalTable: "Places",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Places_PlaceID",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Tools_PlaceID",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "PlaceID",
                table: "Tools");
        }
    }
}

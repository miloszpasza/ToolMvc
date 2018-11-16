using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolMvc.Migrations
{
    public partial class modifyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Places_PlaceID",
                table: "Tools");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tools",
                newName: "ToolID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Places",
                newName: "PlaceID");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceID",
                table: "Tools",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Places_PlaceID",
                table: "Tools",
                column: "PlaceID",
                principalTable: "Places",
                principalColumn: "PlaceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Places_PlaceID",
                table: "Tools");

            migrationBuilder.RenameColumn(
                name: "ToolID",
                table: "Tools",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PlaceID",
                table: "Places",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceID",
                table: "Tools",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Places_PlaceID",
                table: "Tools",
                column: "PlaceID",
                principalTable: "Places",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

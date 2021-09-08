using Microsoft.EntityFrameworkCore.Migrations;

namespace NotDefterim.Data.Migrations
{
    public partial class AuthorIdZorunlu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_AuthorId",
                table: "Notes");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_AuthorId",
                table: "Notes",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_AuthorId",
                table: "Notes");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_AuthorId",
                table: "Notes",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

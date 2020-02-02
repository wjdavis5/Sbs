using Microsoft.EntityFrameworkCore.Migrations;

namespace SbsWeb.Migrations
{
    public partial class Update_Owner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GivenName",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Boards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_EmailAddress",
                table: "Owners",
                column: "EmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Owners_EmailAddress",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "GivenName",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Boards");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

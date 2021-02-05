using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib.Infra.Data.Persistence.Migrations
{
    public partial class ChangeDispalyOrderIntoOrderInGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Genres",
                newName: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Genres",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Genres",
                newName: "DisplayOrder");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}

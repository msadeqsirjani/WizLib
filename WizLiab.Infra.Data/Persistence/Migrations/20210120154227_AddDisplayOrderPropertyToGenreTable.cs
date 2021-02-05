using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib.Infra.Data.Persistence.Migrations
{
    public partial class AddDisplayOrderPropertyToGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Genres");
        }
    }
}

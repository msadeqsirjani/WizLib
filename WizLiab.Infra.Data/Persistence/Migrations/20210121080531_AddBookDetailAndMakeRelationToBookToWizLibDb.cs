using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib.Infra.Data.Persistence.Migrations
{
    public partial class AddBookDetailAndMakeRelationToBookToWizLibDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetailId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetailId",
                table: "Books",
                column: "BookDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetailId",
                table: "Books",
                column: "BookDetailId",
                principalTable: "BookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetailId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetailId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookDetailId",
                table: "Books");
        }
    }
}

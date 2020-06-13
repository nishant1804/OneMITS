using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneMits.Data.Migrations
{
    public partial class ascxv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusCategoryId",
                table: "Status",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatusCategories",
                columns: table => new
                {
                    StatusCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusCategoryTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCategories", x => x.StatusCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Status_StatusCategoryId",
                table: "Status",
                column: "StatusCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_StatusCategories_StatusCategoryId",
                table: "Status",
                column: "StatusCategoryId",
                principalTable: "StatusCategories",
                principalColumn: "StatusCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_StatusCategories_StatusCategoryId",
                table: "Status");

            migrationBuilder.DropTable(
                name: "StatusCategories");

            migrationBuilder.DropIndex(
                name: "IX_Status_StatusCategoryId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "StatusCategoryId",
                table: "Status");
        }
    }
}

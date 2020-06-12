using Microsoft.EntityFrameworkCore.Migrations;

namespace OneMits.Data.Migrations
{
    public partial class tstmig16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnreadNotification",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnreadNotification",
                table: "AspNetUsers");
        }
    }
}

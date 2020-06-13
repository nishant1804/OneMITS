using Microsoft.EntityFrameworkCore.Migrations;

namespace OneMits.Data.Migrations
{
    public partial class tstmig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User2",
                table: "ConnectingList",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "User1",
                table: "ConnectingList",
                newName: "Sender");

            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "ConnectingList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "ConnectingList");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ConnectingList",
                newName: "User2");

            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "ConnectingList",
                newName: "User1");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace OneMits.Data.Migrations
{
    public partial class tstmig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "ConnectingList",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "Receiver",
                table: "ConnectingList",
                newName: "ReceiverId");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "ConnectingList",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "ConnectingList",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConnectingList_ReceiverId",
                table: "ConnectingList",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectingList_SenderId",
                table: "ConnectingList",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectingList_AspNetUsers_ReceiverId",
                table: "ConnectingList",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectingList_AspNetUsers_SenderId",
                table: "ConnectingList",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectingList_AspNetUsers_ReceiverId",
                table: "ConnectingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectingList_AspNetUsers_SenderId",
                table: "ConnectingList");

            migrationBuilder.DropIndex(
                name: "IX_ConnectingList_ReceiverId",
                table: "ConnectingList");

            migrationBuilder.DropIndex(
                name: "IX_ConnectingList_SenderId",
                table: "ConnectingList");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "ConnectingList",
                newName: "Sender");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "ConnectingList",
                newName: "Receiver");

            migrationBuilder.AlterColumn<string>(
                name: "Sender",
                table: "ConnectingList",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "ConnectingList",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

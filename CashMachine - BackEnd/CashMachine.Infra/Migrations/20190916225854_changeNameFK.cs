using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashMachine.Infra.Migrations
{
    public partial class changeNameFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Account",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "Account",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Account_UserId",
            //    table: "Account",
            //    column: "UserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Account_User_UserId",
            //    table: "Account",
            //    column: "UserId",
            //    principalTable: "User",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_UserId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_UserId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Account",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId1",
                table: "Account",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_UserId1",
                table: "Account",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

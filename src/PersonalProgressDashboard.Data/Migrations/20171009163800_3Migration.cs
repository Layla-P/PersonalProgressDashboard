using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalProgressDashboard.Data.Migrations
{
    public partial class _3Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalGoals_AspNetUsers_ApplicationUserId1",
                table: "PersonalGoals");

            migrationBuilder.DropIndex(
                name: "IX_PersonalGoals_ApplicationUserId1",
                table: "PersonalGoals");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PersonalGoals");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PersonalGoals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_PersonalGoals_ApplicationUserId",
                table: "PersonalGoals",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalGoals_AspNetUsers_ApplicationUserId",
                table: "PersonalGoals",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalGoals_AspNetUsers_ApplicationUserId",
                table: "PersonalGoals");

            migrationBuilder.DropIndex(
                name: "IX_PersonalGoals_ApplicationUserId",
                table: "PersonalGoals");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "PersonalGoals",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "PersonalGoals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalGoals_ApplicationUserId1",
                table: "PersonalGoals",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalGoals_AspNetUsers_ApplicationUserId1",
                table: "PersonalGoals",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

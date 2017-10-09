using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalProgressDashboard.Data.Migrations
{
    public partial class _4MigrationChangedFKType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMantras_AspNetUsers_ApplicationUserId1",
                table: "PersonalMantras");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMetrics_AspNetUsers_ApplicationUserId1",
                table: "PersonalMetrics");

            migrationBuilder.DropIndex(
                name: "IX_PersonalMetrics_ApplicationUserId1",
                table: "PersonalMetrics");

            migrationBuilder.DropIndex(
                name: "IX_PersonalMantras_ApplicationUserId1",
                table: "PersonalMantras");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PersonalMetrics");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PersonalMantras");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PersonalMetrics",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PersonalMantras",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMetrics_ApplicationUserId",
                table: "PersonalMetrics",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMantras_ApplicationUserId",
                table: "PersonalMantras",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMantras_AspNetUsers_ApplicationUserId",
                table: "PersonalMantras",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMetrics_AspNetUsers_ApplicationUserId",
                table: "PersonalMetrics",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMantras_AspNetUsers_ApplicationUserId",
                table: "PersonalMantras");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMetrics_AspNetUsers_ApplicationUserId",
                table: "PersonalMetrics");

            migrationBuilder.DropIndex(
                name: "IX_PersonalMetrics_ApplicationUserId",
                table: "PersonalMetrics");

            migrationBuilder.DropIndex(
                name: "IX_PersonalMantras_ApplicationUserId",
                table: "PersonalMantras");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "PersonalMetrics",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "PersonalMetrics",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "PersonalMantras",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "PersonalMantras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMetrics_ApplicationUserId1",
                table: "PersonalMetrics",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMantras_ApplicationUserId1",
                table: "PersonalMantras",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMantras_AspNetUsers_ApplicationUserId1",
                table: "PersonalMantras",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMetrics_AspNetUsers_ApplicationUserId1",
                table: "PersonalMetrics",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

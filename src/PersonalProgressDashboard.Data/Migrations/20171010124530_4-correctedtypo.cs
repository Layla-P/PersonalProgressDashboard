using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalProgressDashboard.Data.Migrations
{
    public partial class _4correctedtypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcheivedDate",
                table: "PersonalGoals");

            migrationBuilder.AddColumn<DateTime>(
                name: "AchievedDate",
                table: "PersonalGoals",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AchievedDate",
                table: "PersonalGoals");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcheivedDate",
                table: "PersonalGoals",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class EditContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleMapsAddress",
                table: "Contact");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndOfTheWorkingDay",
                table: "Contact",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartOfTheWorkingDay",
                table: "Contact",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndOfTheWorkingDay",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "StartOfTheWorkingDay",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "GoogleMapsAddress",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

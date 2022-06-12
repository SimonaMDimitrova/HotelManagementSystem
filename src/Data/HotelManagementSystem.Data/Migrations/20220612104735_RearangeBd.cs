using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class RearangeBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsPageInfo_Image_ImageId",
                table: "AboutUsPageInfo");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_AboutUsPageInfo_ImageId",
                table: "AboutUsPageInfo");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AboutUsPageInfo");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AboutUsPageInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AboutUsPageInfo");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "AboutUsPageInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsPageInfo_ImageId",
                table: "AboutUsPageInfo",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IsDeleted",
                table: "Image",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsPageInfo_Image_ImageId",
                table: "AboutUsPageInfo",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }
    }
}

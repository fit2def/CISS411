using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CISS411.Migrations
{
    public partial class _3423 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Books_CurrentBookTitle",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrentBookTitle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CurrentBookTitle",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFilename",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNext",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "AmazonLink",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFilename",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentBookID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrentBookID",
                table: "AspNetUsers",
                column: "CurrentBookID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Books_CurrentBookID",
                table: "AspNetUsers",
                column: "CurrentBookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Books_CurrentBookID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrentBookID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ImageFilename",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsNext",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AmazonLink",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImageFilename",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CurrentBookID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentBookTitle",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrentBookTitle",
                table: "AspNetUsers",
                column: "CurrentBookTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Books_CurrentBookTitle",
                table: "AspNetUsers",
                column: "CurrentBookTitle",
                principalTable: "Books",
                principalColumn: "Title",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

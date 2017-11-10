using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CISS411.Migrations
{
    public partial class m1000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventsAttended",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "MaxSeat",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxSeat",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventsAttended",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}

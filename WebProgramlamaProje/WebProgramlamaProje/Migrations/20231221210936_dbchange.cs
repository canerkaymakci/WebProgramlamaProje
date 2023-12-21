using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Migrations
{
    public partial class dbchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "TicketTypeProperty");

            migrationBuilder.DropColumn(
                name: "CreaterUser",
                schema: "dbo",
                table: "TicketTypeProperty");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "TicketTypeProperty");

            migrationBuilder.DropColumn(
                name: "LastModifierUser",
                schema: "dbo",
                table: "TicketTypeProperty");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "CreaterUser",
                schema: "dbo",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "LastModifierUser",
                schema: "dbo",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CreaterUser",
                schema: "dbo",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "LastModifierUser",
                schema: "dbo",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "CreaterUser",
                schema: "dbo",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "LastModifierUser",
                schema: "dbo",
                table: "Flight");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "TicketTypeProperty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreaterUser",
                schema: "dbo",
                table: "TicketTypeProperty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "TicketTypeProperty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifierUser",
                schema: "dbo",
                table: "TicketTypeProperty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "TicketType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreaterUser",
                schema: "dbo",
                table: "TicketType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "TicketType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifierUser",
                schema: "dbo",
                table: "TicketType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreaterUser",
                schema: "dbo",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifierUser",
                schema: "dbo",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Flight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreaterUser",
                schema: "dbo",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Flight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifierUser",
                schema: "dbo",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

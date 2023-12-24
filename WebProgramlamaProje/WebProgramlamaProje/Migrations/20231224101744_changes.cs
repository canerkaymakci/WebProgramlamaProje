using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketTypeProperty",
                schema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                schema: "dbo",
                table: "TicketType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Properties",
                schema: "dbo",
                table: "TicketType");

            migrationBuilder.CreateTable(
                name: "TicketTypeProperty",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypeProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTypeProperty_TicketType_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalSchema: "dbo",
                        principalTable: "TicketType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypeProperty_TicketTypeId",
                schema: "dbo",
                table: "TicketTypeProperty",
                column: "TicketTypeId");
        }
    }
}

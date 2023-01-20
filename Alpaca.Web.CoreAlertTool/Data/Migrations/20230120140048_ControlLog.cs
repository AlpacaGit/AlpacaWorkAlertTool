using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpaca.Web.CoreAlertTool.Data.Migrations
{
    public partial class ControlLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlLog",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    SessionID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageID = table.Column<int>(type: "int", nullable: false),
                    LogDetail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlLog", x => x.RecId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlLog");
        }
    }
}

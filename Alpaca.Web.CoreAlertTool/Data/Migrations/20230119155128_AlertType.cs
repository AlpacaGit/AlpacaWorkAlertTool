using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpaca.Web.CoreAlertTool.Data.Migrations
{
    public partial class AlertType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlertType",
                columns: table => new
                {
                    AlertTypeId = table.Column<int>(type: "int", nullable: false),
                    AlertTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertType", x => x.AlertTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertType");
        }
    }
}

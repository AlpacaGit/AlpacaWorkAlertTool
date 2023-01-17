using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpaca.Web.CoreAlertTool.Data.Migrations
{
    public partial class AlertInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlertInfo",
                columns: table => new
                {
                    AlertId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlertTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertInfo", x => x.AlertId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertInfo");
        }
    }
}

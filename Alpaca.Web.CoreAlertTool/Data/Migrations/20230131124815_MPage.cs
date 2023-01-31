using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpaca.Web.CoreAlertTool.Data.Migrations
{
    public partial class MPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_Pages",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Pages", x => x.PageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M_Pages");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCrawler_1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetUrls",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewSearch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetUrls", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetUrls");
        }
    }
}

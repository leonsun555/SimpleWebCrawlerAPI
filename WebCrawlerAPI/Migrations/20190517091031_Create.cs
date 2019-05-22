using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCrawlerAPI.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsLists",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    imgUrl = table.Column<string>(nullable: true),
                    contextUrl = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLists", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsLists");
        }
    }
}

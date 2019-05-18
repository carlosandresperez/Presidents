using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace President.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresidentInfo",
                columns: table => new
                {
                    PresidentName = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Birthplace = table.Column<string>(nullable: true),
                    Deathday = table.Column<DateTime>(nullable: false),
                    Deathplace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresidentInfo", x => x.PresidentName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresidentInfo");
        }
    }
}

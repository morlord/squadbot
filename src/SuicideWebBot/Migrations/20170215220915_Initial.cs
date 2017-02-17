using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SuicideWebBot.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Atck = table.Column<int>(nullable: false),
                    Def = table.Column<int>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Money = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Stamina = table.Column<int>(nullable: false),
                    TgId = table.Column<long>(nullable: false),
                    TgName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}

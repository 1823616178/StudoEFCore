using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspEfCore.Data.Migrations
{
    public partial class updata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MayorId",
                table: "Cities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mayors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mayors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_MayorId",
                table: "Cities",
                column: "MayorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_mayors_MayorId",
                table: "Cities",
                column: "MayorId",
                principalTable: "mayors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_mayors_MayorId",
                table: "Cities");

            migrationBuilder.DropTable(
                name: "mayors");

            migrationBuilder.DropIndex(
                name: "IX_Cities_MayorId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "MayorId",
                table: "Cities");
        }
    }
}

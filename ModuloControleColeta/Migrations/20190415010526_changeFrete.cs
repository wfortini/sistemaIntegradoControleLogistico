using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuloControleColeta.Migrations
{
    public partial class changeFrete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataPrevista",
                table: "Frete",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "prazoEntregaDias",
                table: "Frete",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataPrevista",
                table: "Frete");

            migrationBuilder.DropColumn(
                name: "prazoEntregaDias",
                table: "Frete");
        }
    }
}

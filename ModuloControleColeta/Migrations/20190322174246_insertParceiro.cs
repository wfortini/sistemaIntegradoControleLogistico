using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuloControleColeta.Migrations
{
    public partial class insertParceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParceiroId",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_ParceiroId",
                table: "Solicitacao",
                column: "ParceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Usuario_ParceiroId",
                table: "Solicitacao",
                column: "ParceiroId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Usuario_ParceiroId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_ParceiroId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "ParceiroId",
                table: "Solicitacao");
        }
    }
}

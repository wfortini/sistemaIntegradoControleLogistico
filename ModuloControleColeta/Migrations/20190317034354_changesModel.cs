using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuloControleColeta.Migrations
{
    public partial class changesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteSolicitanteId",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinoId",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreteId",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdutoId",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Solicitacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataPrevistaEntrega",
                table: "Solicitacao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataSolicitacao",
                table: "Solicitacao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    CEP = table.Column<string>(nullable: true),
                    CPFCNPJDestinatatio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frete",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Peso = table.Column<string>(nullable: true),
                    valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_ClienteSolicitanteId",
                table: "Solicitacao",
                column: "ClienteSolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_DestinoId",
                table: "Solicitacao",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_FreteId",
                table: "Solicitacao",
                column: "FreteId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_ProdutoId",
                table: "Solicitacao",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Cliente_ClienteSolicitanteId",
                table: "Solicitacao",
                column: "ClienteSolicitanteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Destino_DestinoId",
                table: "Solicitacao",
                column: "DestinoId",
                principalTable: "Destino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Frete_FreteId",
                table: "Solicitacao",
                column: "FreteId",
                principalTable: "Frete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Produto_ProdutoId",
                table: "Solicitacao",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Cliente_ClienteSolicitanteId",
                table: "Solicitacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Destino_DestinoId",
                table: "Solicitacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Frete_FreteId",
                table: "Solicitacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Produto_ProdutoId",
                table: "Solicitacao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Frete");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_ClienteSolicitanteId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_DestinoId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_FreteId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_ProdutoId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "ClienteSolicitanteId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "DestinoId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "FreteId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "dataPrevistaEntrega",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "dataSolicitacao",
                table: "Solicitacao");
        }
    }
}

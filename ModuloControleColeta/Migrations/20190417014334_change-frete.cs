using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuloControleColeta.Migrations
{
    public partial class changefrete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Produto",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nCdEmpresa",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nCdFormato",
                table: "Produto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nCdServico",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "nVlAltura",
                table: "Produto",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "nVlComprimento",
                table: "Produto",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "nVlDiametro",
                table: "Produto",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "nVlLargura",
                table: "Produto",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "nVlPeso",
                table: "Produto",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "nVlValorDeclarado",
                table: "Produto",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "sCdAvisoRecebimento",
                table: "Produto",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sCdMaoPropria",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sCepDestino",
                table: "Produto",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sCepOrigem",
                table: "Produto",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sDsSenha",
                table: "Produto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nCdEmpresa",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nCdFormato",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nCdServico",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nVlAltura",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nVlComprimento",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nVlDiametro",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nVlLargura",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nVlPeso",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "nVlValorDeclarado",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "sCdAvisoRecebimento",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "sCdMaoPropria",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "sCepDestino",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "sCepOrigem",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "sDsSenha",
                table: "Produto");
        }
    }
}

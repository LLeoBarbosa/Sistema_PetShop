using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_PetShop.Migrations
{
    public partial class Add_NotaFiscal_TipoPagamento_IntercsNotasETipoPagamento_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cpf = table.Column<int>(maxLength: 11, nullable: false),
                    Endereco = table.Column<string>(maxLength: 100, nullable: false),
                    Cep = table.Column<string>(maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(maxLength: 25, nullable: false),
                    Uf = table.Column<string>(nullable: false),
                    TelFixo = table.Column<string>(maxLength: 11, nullable: false),
                    TelMovel1 = table.Column<string>(maxLength: 12, nullable: false),
                    TelMovel2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "TiposPagamentos",
                columns: table => new
                {
                    TipoPagamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Parcelado = table.Column<string>(nullable: false),
                    QtdParcelas = table.Column<int>(maxLength: 1, nullable: false),
                    ValorMinimo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPagamentos", x => x.TipoPagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    NumeroNota = table.Column<int>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    Detalhes = table.Column<string>(maxLength: 100, nullable: false),
                    CLienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => new { x.NumeroNota, x.DataVenda });
                    table.UniqueConstraint("AK_NotasFiscais_DataVenda_NumeroNota", x => new { x.DataVenda, x.NumeroNota });
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Clientes_CLienteId",
                        column: x => x.CLienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntercPagamentoNota",
                columns: table => new
                {
                    NumeroNota = table.Column<int>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    TipoPagamentoId = table.Column<int>(nullable: false),
                    ValorPago = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntercPagamentoNota", x => new { x.NumeroNota, x.DataVenda, x.TipoPagamentoId });
                    table.UniqueConstraint("AK_IntercPagamentoNota_DataVenda_NumeroNota_TipoPagamentoId", x => new { x.DataVenda, x.NumeroNota, x.TipoPagamentoId });
                    table.ForeignKey(
                        name: "FK_IntercPagamentoNota_TiposPagamentos_TipoPagamentoId",
                        column: x => x.TipoPagamentoId,
                        principalTable: "TiposPagamentos",
                        principalColumn: "TipoPagamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntercPagamentoNota_NotasFiscais_NumeroNota_DataVenda",
                        columns: x => new { x.NumeroNota, x.DataVenda },
                        principalTable: "NotasFiscais",
                        principalColumns: new[] { "NumeroNota", "DataVenda" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntercProdutoNota",
                columns: table => new
                {
                    NumeroNota = table.Column<int>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    QTDVendida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntercProdutoNota", x => new { x.NumeroNota, x.DataVenda, x.ProdutoId });
                    table.UniqueConstraint("AK_IntercProdutoNota_DataVenda_NumeroNota_ProdutoId", x => new { x.DataVenda, x.NumeroNota, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_IntercProdutoNota_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntercProdutoNota_NotasFiscais_NumeroNota_DataVenda",
                        columns: x => new { x.NumeroNota, x.DataVenda },
                        principalTable: "NotasFiscais",
                        principalColumns: new[] { "NumeroNota", "DataVenda" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntercPagamentoNota_TipoPagamentoId",
                table: "IntercPagamentoNota",
                column: "TipoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_IntercProdutoNota_ProdutoId",
                table: "IntercProdutoNota",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_CLienteId",
                table: "NotasFiscais",
                column: "CLienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntercPagamentoNota");

            migrationBuilder.DropTable(
                name: "IntercProdutoNota");

            migrationBuilder.DropTable(
                name: "TiposPagamentos");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

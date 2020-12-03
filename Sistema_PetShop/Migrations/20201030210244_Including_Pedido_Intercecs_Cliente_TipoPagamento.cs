using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_PetShop.Migrations
{
    public partial class Including_Pedido_Intercecs_Cliente_TipoPagamento : Migration
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
                name: "Pedidos",
                columns: table => new
                {
                    NumeroPedido = table.Column<int>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    Detalhes = table.Column<string>(maxLength: 100, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => new { x.NumeroPedido, x.DataVenda });
                    table.UniqueConstraint("AK_Pedidos_DataVenda_NumeroPedido", x => new { x.DataVenda, x.NumeroPedido });
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos_Pedidos",
                columns: table => new
                {
                    NumeroPedido = table.Column<int>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    TipoPagamentoId = table.Column<int>(nullable: false),
                    ValorPago = table.Column<decimal>(nullable: false),
                    NumeroTransacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos_Pedidos", x => new { x.NumeroPedido, x.DataVenda, x.TipoPagamentoId });
                    table.UniqueConstraint("AK_Pagamentos_Pedidos_DataVenda_NumeroPedido_TipoPagamentoId", x => new { x.DataVenda, x.NumeroPedido, x.TipoPagamentoId });
                    table.ForeignKey(
                        name: "FK_Pagamentos_Pedidos_TiposPagamentos_TipoPagamentoId",
                        column: x => x.TipoPagamentoId,
                        principalTable: "TiposPagamentos",
                        principalColumn: "TipoPagamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Pedidos_Pedidos_NumeroPedido_DataVenda",
                        columns: x => new { x.NumeroPedido, x.DataVenda },
                        principalTable: "Pedidos",
                        principalColumns: new[] { "NumeroPedido", "DataVenda" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos_Pedidos",
                columns: table => new
                {
                    NumeroPedido = table.Column<int>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    QTDVendida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos_Pedidos", x => new { x.NumeroPedido, x.DataVenda, x.ProdutoId });
                    table.UniqueConstraint("AK_Produtos_Pedidos_DataVenda_NumeroPedido_ProdutoId", x => new { x.DataVenda, x.NumeroPedido, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_Produtos_Pedidos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Pedidos_Pedidos_NumeroPedido_DataVenda",
                        columns: x => new { x.NumeroPedido, x.DataVenda },
                        principalTable: "Pedidos",
                        principalColumns: new[] { "NumeroPedido", "DataVenda" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_Pedidos_TipoPagamentoId",
                table: "Pagamentos_Pedidos",
                column: "TipoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Pedidos_ProdutoId",
                table: "Produtos_Pedidos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos_Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos_Pedidos");

            migrationBuilder.DropTable(
                name: "TiposPagamentos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

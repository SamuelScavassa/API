using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteIdCliente = table.Column<int>(type: "int", nullable: false),
                    aprovado = table.Column<bool>(type: "bit", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_clienteIdCliente",
                        column: x => x.clienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeProduto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    preco = table.Column<double>(type: "float", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PedidosidPedido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.idProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Pedidos_PedidosidPedido",
                        column: x => x.PedidosidPedido,
                        principalTable: "Pedidos",
                        principalColumn: "idPedido");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_clienteIdCliente",
                table: "Pedidos",
                column: "clienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidosidPedido",
                table: "Produtos",
                column: "PedidosidPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}

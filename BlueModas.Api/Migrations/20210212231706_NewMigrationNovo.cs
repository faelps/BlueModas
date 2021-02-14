using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueModas.Api.Migrations
{
    public partial class NewMigrationNovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeroDoPedido",
                table: "Pedido",
                newName: "NumeroDoPedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItemPedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroDoPedido",
                table: "Pedido",
                newName: "NomeroDoPedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItemPedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

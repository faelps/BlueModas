namespace BlueModas.Api.Model
{
    public class ItemPedido
    {
        public ItemPedido()
        {

        }
        public ItemPedido(int produtoId, int quantidade, int pedidoId)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            PedidoId = pedidoId;
        }

        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public virtual Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int PedidoId { get; private set; }

    }
}

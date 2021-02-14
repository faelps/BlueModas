using BlueModas.Api.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Model
{
    public class Pedido
    {
        public Pedido()
        {

        }
        
        public Pedido(int id, DateTime dataDoPedido, decimal valorDoPedido, string clienteId, List<ItemPedido> itensDoPedido)
        {
            Id = id;
            DataDoPedido = dataDoPedido;
            ValorDoPedido = valorDoPedido;
            ClienteId = clienteId;
            ItensDoPedido = itensDoPedido;
        }

        public int Id { get; private set; }
        public DateTime DataDoPedido { get; private set; }
        public string NumeroDoPedido { get; private set; }
        public decimal ValorDoPedido { get; private set; }
        public string ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public List<ItemPedido> ItensDoPedido { get; private set; } 

        public string AdicionarNumeroDoPedido()
        {
            Random r = new Random();
            int rInt = r.Next(0, 100);

            this.NumeroDoPedido = Convert.ToString(rInt);
            return this.NumeroDoPedido;
        }

        internal List<ItemPedido> AdicionarIntensDoPedido(List<ItemPedidoDto> itensDoPedido)
        {
            var lista = new List<ItemPedido>();
            foreach (var item in itensDoPedido)
            {
                var itemPedido = new ItemPedido(item.Produto.Id, item.Quantidade, item.PedidoId);
                lista.Add(itemPedido);
            }
            return lista;
        }

        public decimal CalcularValorTotalDoPedido()
        {
            this.ValorDoPedido = ItensDoPedido.Sum(x => x.Produto.Preco);
            return this.ValorDoPedido;
        }

        public void AdicionarClienteId(string clienteId)
        {
            this.ClienteId = clienteId;
        }
        //internal void CriarPedido(Pedido pedido)
        //{
        //    this.ValorDoPedido = ItensDoPedido.Sum(x => x.Produto.Preco);
        //    this.DataDoPedido = pedido.DataDoPedido;
        //    this.NumeroDoPedido = AdicionarNumeroDoPedido();
        //    this.ClienteId = pedido.ClienteId;
        //    this.ItensDoPedido = pedido.ItensDoPedido;
        //}
    }
}

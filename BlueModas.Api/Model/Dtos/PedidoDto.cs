using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Model.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime DataDoPedido { get; set; }
        public string NumeroDoPedido { get; set; }
        public decimal ValorDoPedido { get; set; }
        public string ClienteId { get; set; }
        public virtual ClienteDto Cliente { get; set; }
        public List<ItemPedidoDto> ItensDoPedido { get; set; }
    }
}

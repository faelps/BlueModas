using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Model.Dtos
{
    public class ItemPedidoDto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual ProdutoDto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int PedidoId { get; set; }
    }
}

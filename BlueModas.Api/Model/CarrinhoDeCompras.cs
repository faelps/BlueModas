using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Model
{
    public class CarrinhoDeCompras
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}

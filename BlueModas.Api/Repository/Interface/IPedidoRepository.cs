using BlueModas.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Repository.Interface
{
    public interface IPedidoRepository
    {
        Task<int> GravarPedido(Pedido pedido);
        Task<List<Pedido>> ObterPedidosPeloIdDoCliente(string id);
    }
}

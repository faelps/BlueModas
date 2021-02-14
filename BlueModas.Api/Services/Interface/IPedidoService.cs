using BlueModas.Api.Model;
using BlueModas.Api.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModas.Api.Services.Interface
{
    public interface IPedidoService
    {
        Task<int> GravarPedido(PedidoDto pedido);
        //Task<Pedido> GravarPedidoEstatico(Pedido pedido);
        Task<List<Pedido>> ObterPedidoPeloIdDoCliente(string id);
    }
}

using BlueModas.Api.Model;
using BlueModas.Api.Model.Dtos;
using BlueModas.Api.Repository.Interface;
using BlueModas.Api.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IClienteService clienteService;
        private readonly IPedidoRepository pedidoRepository;
        public PedidoService(IClienteService clienteService, IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.clienteService = clienteService;

        }
        public async Task<int> GravarPedido(PedidoDto pedido)
        {
            if (await clienteService.ObterClientePorId(pedido.Cliente.Id) != null)
            {
                var listaDeItens = new List<ItemPedido>();
                foreach (var item in pedido.ItensDoPedido)
                {
                   listaDeItens.Add(new ItemPedido(item.Produto.Id, item.Quantidade, item.PedidoId));
                }
                var pedidoModel = new Pedido(pedido.Id, pedido.DataDoPedido, pedido.ValorDoPedido, pedido.Cliente.Id, listaDeItens);
                pedidoModel.AdicionarNumeroDoPedido();
                return await pedidoRepository.GravarPedido(pedidoModel);
            }
            else
            {
                var clienteId = await clienteService.AdicionarCliente(pedido.Cliente);
                var listaDeItens = new List<ItemPedido>();
                foreach (var item in pedido.ItensDoPedido)
                {
                    listaDeItens.Add(new ItemPedido(item.Produto.Id, item.Quantidade, item.PedidoId));
                }
                var pedidoContrutor = new Pedido(pedido.Id, pedido.DataDoPedido, pedido.ValorDoPedido, clienteId, listaDeItens);
                pedidoContrutor.AdicionarNumeroDoPedido();
                return await pedidoRepository.GravarPedido(pedidoContrutor);
            }
        }

        public async Task<List<Pedido>> ObterPedidoPeloIdDoCliente(string id)
        {
            return await pedidoRepository.ObterPedidosPeloIdDoCliente(id);
        }
    }
}

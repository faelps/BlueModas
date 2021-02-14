using BlueModas.Api.Model;
using BlueModas.Api.Repository.BlueContext;
using BlueModas.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly LojaBlueContext lojaBlueContext;
        public PedidoRepository(LojaBlueContext lojaBlueContext)
        {
            this.lojaBlueContext = lojaBlueContext;
        }
        public async Task<int> GravarPedido(Pedido pedido)
        {
            var pedidoSalvo = await  lojaBlueContext.AddAsync(pedido);
            await lojaBlueContext.SaveChangesAsync();
            return pedidoSalvo.Entity.Id;
        }

        public async Task<List<Pedido>> ObterPedidosPeloIdDoCliente(string id)
        {
            var pedidos =  await lojaBlueContext.Pedido
                                 .Include(x => x.ItensDoPedido)
                                    .ThenInclude(p => p.Produto)
                                  .Include(x => x.Cliente)  
                                .Where(x => x.ClienteId == id).ToListAsync();
            return pedidos;
        }
    }
}

using BlueModas.Api.Factory;
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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly LojaBlueContext lojaBlueContext;
        public ProdutoRepository(LojaBlueContext lojaBlueContext)
        {
            this.lojaBlueContext = lojaBlueContext;
        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            //var listaDeProtudos = ProdutoFactory.CriarProdutos();
            //return listaDeProtudos.FirstOrDefault(x => x.Id.Equals(id));
            return await lojaBlueContext.Produto.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Produto>> ObterTodosOsProdutos()
        {
            //var listaDeProtudos = ProdutoFactory.CriarProdutos();
            //return listaDeProtudos;
            return await lojaBlueContext.Produto.ToListAsync();
        }

        public async Task<int> SalvarProduto(Produto produto)
        {
            await lojaBlueContext.AddAsync(produto);
            await lojaBlueContext.SaveChangesAsync();
            return produto.Id;
        }
    }
}

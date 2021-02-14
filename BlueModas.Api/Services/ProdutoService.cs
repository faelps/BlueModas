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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IClienteService clienteService;
        private readonly IPedidoService pedidoService;
        public ProdutoService(IProdutoRepository produtoRepository, IClienteService clienteService, IPedidoService pedidoService)
        {
            this.produtoRepository = produtoRepository;
            this.clienteService = clienteService;
            this.pedidoService = pedidoService;
        }
        public Task AtulizarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GravarProduto(ProdutoDto produto)
        {
            var produdoModel = new Produto(produto.Id, produto.Nome, produto.Preco, produto.Imagem);
            var produtoId = await produtoRepository.SalvarProduto(produdoModel);
            return produtoId;
        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            return await produtoRepository.ObterProdutoPorId(id);
        }

        public async Task<List<Produto>> ObterTodosOsProdutos()
        {
            return await produtoRepository.ObterTodosOsProdutos();
        }
    }
}

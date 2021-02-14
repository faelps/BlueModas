using BlueModas.Api.Repository.Interface;
using BlueModas.Api.Services;
using BlueModas.Api.Services.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlueModas.Teste.Produto.ProdutoServiceTeste
{

    public class ProdutoServiceTeste
    {
        private readonly Mock<IProdutoRepository> produtoRepositoryMock;
        private readonly Mock<IClienteService> clienteServiceMock;
        private readonly Mock<IPedidoService> pedidoServiceMock;
        public ProdutoServiceTeste()
        {
            this.produtoRepositoryMock = new Mock<IProdutoRepository>();
            this.clienteServiceMock = new Mock<IClienteService>();
            this.pedidoServiceMock = new Mock<IPedidoService>();
        }
        [Fact]
        public void DeveCriarUmNovoProduto()
        {
            var produtoDto = new BlueModas.Api.Model.Dtos.ProdutoDto
            {
            Imagem = "UrlImagem",
            Nome = "Camisa gola polo",
            Preco = 22.30M
            };

            var produtoModel = new BlueModas.Api.Model.Produto(produtoDto.Id, produtoDto.Nome, produtoDto.Preco, produtoDto.Imagem);


            var produtoService = new ProdutoService(produtoRepositoryMock.Object, clienteServiceMock.Object, pedidoServiceMock.Object);
            produtoRepositoryMock.Setup(x => x.SalvarProduto(produtoModel)).Returns(Task.Run(() => produtoModel.Id));
            var result = produtoService.GravarProduto(produtoDto);

            Assert.Equal(result.Result, produtoModel.Id);
        }
        [Fact]
        public void DeveObterOProdutoPorId()
        {
            var id = 1;
            var produto = new BlueModas.Api.Model.Produto(1, "Camisa gola polo", 22.30M, "UrlImagem");

            var produtoService = new ProdutoService(produtoRepositoryMock.Object, clienteServiceMock.Object, pedidoServiceMock.Object);
            produtoRepositoryMock.Setup(x => x.ObterProdutoPorId(id)).Returns(Task.Run(() => produto));
            var result = produtoService.ObterProdutoPorId(id);

            Assert.Equal(produto.Id, result.Result.Id);
        }
        [Fact]
        public void DeveObterTodosOsProdutos()
        {
            var listaDeProdutos = new List<BlueModas.Api.Model.Produto>();
            listaDeProdutos.Add(new BlueModas.Api.Model.Produto(1, "Camisa gola polo", 22.30M, "UrlImagem"));
            listaDeProdutos.Add(new BlueModas.Api.Model.Produto(2, "Camisa gola polo", 22.30M, "UrlImagem"));
            listaDeProdutos.Add(new BlueModas.Api.Model.Produto(3, "Camisa gola polo", 22.30M, "UrlImagem"));
            var produtoService = new ProdutoService(produtoRepositoryMock.Object, clienteServiceMock.Object, pedidoServiceMock.Object);

            produtoRepositoryMock.Setup(x => x.ObterTodosOsProdutos()).Returns(Task.Run(()=> listaDeProdutos));
            var result =  produtoService.ObterTodosOsProdutos();
            Assert.Equal(listaDeProdutos[0].Id, result.Result[0].Id);
            Assert.Equal(listaDeProdutos.Count, result.Result.Count);
        }
    }
}

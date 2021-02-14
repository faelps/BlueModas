using BlueModas.Api.Repository.Interface;
using BlueModas.Api.Services;
using BlueModas.Api.Services.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BlueModas.Teste.Pedido.PedidoServiceTeste
{
    public class PedidoServiceTeste
    {
        private readonly Mock<IClienteService> clienteService;
        private readonly Mock<IPedidoRepository> pedidoRepository;
        public PedidoServiceTeste()
        {
            this.clienteService = new Mock<IClienteService>();
            this.pedidoRepository = new Mock<IPedidoRepository>();
        }

        [Fact]
        public void DeveGravarUmPedidoParaUmClienteNovo()
        {
            var pedidoId = 3;
            var clienteDto = new Api.Model.Dtos.ClienteDto 
            {
               Id = "idDoCliente",
                Nome = "Nome",
                Telefone = "99999",
                Email = "email@emaiul.com"
            };
            var produtoDto = new Api.Model.Dtos.ProdutoDto
            {
                Id = 1,
                Imagem = "UrlImagem",
                Nome = "Camisa gola polo",
                Preco = 22.30M
            };
            var produtoModel = new Api.Model.Produto(produtoDto.Id, produtoDto.Nome, produtoDto.Preco, produtoDto.Imagem);

            var itensDoPedido = new List<Api.Model.Dtos.ItemPedidoDto>();
            var itemPedidoModel = new List<Api.Model.ItemPedido>();
            var pedidoDto = new Api.Model.Dtos.PedidoDto 
            {
            Id = pedidoId,
            Cliente = clienteDto,
            ClienteId = clienteDto.Id,
            DataDoPedido = DateTime.Now,
            ValorDoPedido = 99.90M,
            ItensDoPedido = itensDoPedido
            };
            var pedidoModel = new Api.Model.Pedido(pedidoDto.Id, pedidoDto.DataDoPedido, pedidoDto.ValorDoPedido, pedidoDto.ClienteId, itemPedidoModel);
            var itemPedido = new Api.Model.Dtos.ItemPedidoDto
            { 
            PedidoId = pedidoDto.Id,
            PrecoUnitario = produtoDto.Preco,
            Produto = produtoDto,
            ProdutoId = produtoDto.Id,
            Quantidade = 5,
            Id = 2
            };
            itensDoPedido.Add(itemPedido);
            clienteService.Setup(x => x.AdicionarCliente(clienteDto)).Returns(Task.Run(() => clienteDto.Id));
            pedidoRepository.Setup(x => x.GravarPedido(pedidoModel)).Returns(Task.Run(() => pedidoId));
            var pedidoService = new PedidoService(clienteService.Object, pedidoRepository.Object);

            var result = pedidoService.GravarPedido(pedidoDto);

            Assert.Equal(pedidoId, result.Result);
        }
        [Fact]
        public void DeveGravarUmPedidoParaUmClienteExistente()
        {
            var pedidoEsperadoId = 3;
            var clienteDto = new Api.Model.Dtos.ClienteDto
            {
                Id = "idDoCliente",
                Nome = "Nome",
                Telefone = "99999",
                Email = "email@emaiul.com"
            };

            var clienteModel = new Api.Model.Cliente(clienteDto.Id, clienteDto.Nome, clienteDto.Telefone, clienteDto.Email);
            var produtoDto = new Api.Model.Dtos.ProdutoDto
            {
                Id = 1,
                Imagem = "UrlImagem",
                Nome = "Camisa gola polo",
                Preco = 22.30M
            };
            var produtoModel = new Api.Model.Produto(produtoDto.Id, produtoDto.Nome, produtoDto.Preco, produtoDto.Imagem);

            var itensDoPedido = new List<Api.Model.Dtos.ItemPedidoDto>();

            var pedidoDto = new Api.Model.Dtos.PedidoDto
            {
                Id = pedidoEsperadoId,
                Cliente = clienteDto,
                ClienteId = clienteDto.Id,
                DataDoPedido = DateTime.Now,
                ValorDoPedido = 99.90M,
                ItensDoPedido = itensDoPedido
            };

            
            var itemPedido = new Api.Model.Dtos.ItemPedidoDto
            {
                PedidoId = pedidoDto.Id,
                PrecoUnitario = produtoDto.Preco,
                Produto = produtoDto,
                ProdutoId = produtoDto.Id,
                Quantidade = 5,
                Id = 2
            };
            itensDoPedido.Add(itemPedido);

            var itemPedidoModel = new List<Api.Model.ItemPedido>();

            var pedidoModel = new Api.Model.Pedido(pedidoDto.Id, pedidoDto.DataDoPedido, pedidoDto.ValorDoPedido, pedidoDto.ClienteId, itemPedidoModel);
            clienteService.Setup(x => x.ObterClientePorId(clienteDto.Id)).Returns(Task.Run(() => clienteModel));
            pedidoRepository.Setup(x => x.GravarPedido(pedidoModel)).Returns(Task.Run(() => pedidoEsperadoId));
            var pedidoService = new PedidoService(clienteService.Object, pedidoRepository.Object);

            var result = pedidoService.GravarPedido(pedidoDto);

            Assert.Equal(0, result.Result);
        }
        [Fact]
        public void DeveObterPedidoPeloIdDoCliente()
        {
            var pedidoId = 3;
            var cliente = new Api.Model.Cliente("idDoCliente", "Robsvaldo", "69 69 69", "mail@mail.com");
            var produto = new Api.Model.Produto(1, "Camisa gola polo", 22.30M, "UrlImagem");
            var itemPedido = new Api.Model.ItemPedido(produto.Id, 3, pedidoId);
            var itensDoPedido = new List<Api.Model.ItemPedido>();
            itensDoPedido.Add(itemPedido);
            var pedido = new Api.Model.Pedido(pedidoId, DateTime.Now, 99.90M, cliente.Id, itensDoPedido);

            var listaDePedidos = new List<Api.Model.Pedido>();
            listaDePedidos.Add(pedido);
            pedidoRepository.Setup(x => x.ObterPedidosPeloIdDoCliente(cliente.Id)).Returns(Task.Run(() => listaDePedidos));
            var pedidoService = new PedidoService(clienteService.Object, pedidoRepository.Object);
            var result = pedidoService.ObterPedidoPeloIdDoCliente(cliente.Id);

            Assert.Equal(listaDePedidos[0].Id, result.Result[0].Id);
            Assert.Equal(listaDePedidos.Count, result.Result.Count);
        }

    }
}

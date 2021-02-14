using BlueModas.Api.Model;
using BlueModas.Api.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Services.Interface
{
    public interface IProdutoService
    {
        Task<Produto> ObterProdutoPorId(int id);
        Task<List<Produto>> ObterTodosOsProdutos();
        Task<int> GravarProduto(ProdutoDto produto);
        Task AtulizarProduto(Produto produto);
    }
}

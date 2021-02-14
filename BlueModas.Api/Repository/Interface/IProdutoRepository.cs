using BlueModas.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task<int> SalvarProduto(Produto produto);
        Task<List<Produto>> ObterTodosOsProdutos();
        Task<Produto> ObterProdutoPorId(int id);
    }
}

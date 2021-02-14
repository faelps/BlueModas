using BlueModas.Api.Model;
using BlueModas.Api.Model.Dtos;
using BlueModas.Api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService produtoService;
      
        public ProdutoController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }
        [HttpPost("SalvarProduto/{produto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SalvarProduto(ProdutoDto produto)
        {
            try
            {
                var id = await produtoService.GravarProduto(produto);
                return Ok(new { success = true, message = id });
            }
            catch (Exception ex)
            {

                return BadRequest(new { success = false, message = "Ocorreu um erro, por favor contate o administrador", exmessage = ex.Message });
            }
        }

        [HttpPost("EditarProduto/{produto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarProduto(Produto produto)
        {
            try
            {
                await produtoService.AtulizarProduto(produto);
                return Ok(new { success = true, message = "Produto Atualizado Com Sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { success = false, message = "Ocorreu um erro, por favor contate o administrador", exmessage = ex.Message });
            }
        }

        [HttpGet("ObterTodosOsProdutos")]
        public async Task<List<Produto>> ObterTodosOsProdutos()
        {
            var produto = await produtoService.ObterTodosOsProdutos();
            return produto;
        }
        [HttpGet("ObterProdutoPorId/{id}")]
        public async Task<Produto> ObterProdutoPorId(int id)
        {
            var produto = await produtoService.ObterProdutoPorId(id);
            return produto;
        }
        
    }
}

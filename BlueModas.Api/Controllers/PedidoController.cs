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
    public class PedidoController : BaseController
    {

        private readonly IPedidoService pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        [HttpPost("GravarPedido/{pedido}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GravarPedido(PedidoDto pedido)
        {
            try
            {
                var id = await pedidoService.GravarPedido(pedido);
                //var idPedidoStatico = await pedidoService.GravarPedidoEstatico(ped);
                return Ok(new { success = true, message = id });
            }
            catch (Exception ex)
            {

                return BadRequest(new { success = false, message = "Ocorreu um erro, por favor contate o administrador", exmessage = ex.Message });
            }
        }

        [HttpGet("ObterPedidoPeloIdDoCliente/{id}")]
        public async Task<List<Pedido>> ObterPedidoPeloIdDoCliente(string id)
        {
            try
            {
                var pedido = await pedidoService.ObterPedidoPeloIdDoCliente(id);
                return pedido;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

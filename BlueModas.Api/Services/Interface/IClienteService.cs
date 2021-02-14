using BlueModas.Api.Model;
using BlueModas.Api.Model.Dtos;
using System.Threading.Tasks;

namespace BlueModas.Api.Services.Interface
{
    public interface IClienteService
    {
        Task<Cliente> ObterClientePorId(string id);
        Task<string> AdicionarCliente(ClienteDto cliente);
    }
}

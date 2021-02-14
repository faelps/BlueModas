using BlueModas.Api.Model;
using BlueModas.Api.Model.Dtos;
using BlueModas.Api.Repository.BlueContext;
using BlueModas.Api.Services.Interface;
using System.Threading.Tasks;

namespace BlueModas.Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly LojaBlueContext lojaBlueContext;
        public ClienteService(LojaBlueContext lojaBlueContext)
        {
            this.lojaBlueContext = lojaBlueContext;
        }

        public async Task<string> AdicionarCliente(ClienteDto cliente)
        {
            var clieteModel = new Cliente(cliente.Id, cliente.Nome, cliente.Telefone, cliente.Email);
            var clienteSavo = await lojaBlueContext.AddAsync(clieteModel);
            await lojaBlueContext.SaveChangesAsync();
            return clienteSavo.Entity.Id;
        }

        public async Task<Cliente> ObterClientePorId(string id)
        {
            return await lojaBlueContext.Cliente.FindAsync(id);
        }
    }
}

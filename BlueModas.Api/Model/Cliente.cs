using System;
using System.Collections.Generic;

namespace BlueModas.Api.Model
{
    public class Cliente
    {
        public Cliente(string id, string nome, string telefone, string email)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public ICollection<Pedido> Pedido { get; private set; }
    }
}

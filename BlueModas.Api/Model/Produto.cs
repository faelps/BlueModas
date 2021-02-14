using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Model
{
    public class Produto
    {
        public Produto(int id, string nome, decimal preco, string imagem)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Imagem = imagem;
        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Imagem { get; private set; }

    }
}

using BlueModas.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Factory
{
    public static class ProdutoFactory
    {
        internal static List<Produto> CriarProdutos()
        {
            var lista = new List<Produto>();

            //lista.Add(new Produto { Id = 1,  Preco = new decimal(30.99), Nome  = "Conjunto Masculino", Imagem = "https://images.tcdn.com.br/static_inst/escoladeecommerce/prod/wp-content/uploads/2018/08/como-tirar-fotos-de-roupas.jpg"});
            //lista.Add(new Produto { Id = 2,  Preco = new decimal(22.80), Nome = "Camisas Sociais Masculina", Imagem = "https://cptstatic.s3.amazonaws.com/imagens/produtos/500px/45673/confeccao-de-camisas-masculinas-01.jpg" });
            //lista.Add(new Produto { Id = 3,  Preco = new decimal(50.99), Nome = "Conjunto Feminino", Imagem = "https://i.pinimg.com/736x/95/8d/8f/958d8fc11028b68c22be4fafc530bfa7.jpg" });
            //lista.Add(new Produto { Id = 4,  Preco = new decimal(18.30), Nome = "Conjunto Casual Feminino", Imagem = "https://i.pinimg.com/564x/d5/2a/d7/d52ad71850d23e1733738b8906b76e4a.jpg" });
            //lista.Add(new Produto { Id = 5,  Preco = new decimal(39.99), Nome = "Calça Jeans Feminina", Imagem = "https://i.pinimg.com/originals/b2/81/75/b28175b4edc32c166158082f7238e2be.png" });
            //lista.Add(new Produto { Id = 6,  Preco = new decimal(69.90), Nome = "Calça Jeans Boca de Sino Feminina", Imagem = "https://olook.com.br/wp-content/uploads/2018/10/Looks-com-Calc%CC%A7a-Flare.jpg" });

            return lista;
        }
    }
}

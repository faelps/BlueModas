using BlueModas.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Repository.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                 .Property(p => p.Nome)
                 .IsRequired()
                 .HasColumnType("varchar(200)")
                 .HasMaxLength(200);
        }
    }
}

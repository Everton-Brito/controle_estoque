using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Infra.Data.Mappings
{
    public class MercadoriaMapping : IEntityTypeConfiguration<Mercadoria>
    {
        public void Configure(EntityTypeBuilder<Mercadoria> builder)
        {
            builder.ToTable("MERCADORIA");

            builder.HasKey(m => m.IdMercadoria);

            builder.Property(m => m.IdMercadoria)
                .HasColumnName("IDMERCADORIA")
                .IsRequired();   

            builder.Property(m => m.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(m => m.Registro)
                .HasColumnName("REGISTRO")
                .IsRequired();

            builder.Property(m => m.Fabricante)
                .HasColumnName("FABRICANTE")
                .IsRequired();

            builder.Property(m => m.Tipo)
                .HasColumnName("TIPO")
                .IsRequired();

            builder.Property(m => m.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired();          

            
        }
    }
}

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
    public class EntradaMapping : IEntityTypeConfiguration<Entrada>
    {
        public void Configure(EntityTypeBuilder<Entrada> builder)
        {
            builder.ToTable("ENTRADA");

            builder.HasKey(e => e.IdEntrada);

            builder.Property(e => e.IdEntrada)
                .HasColumnName("IDENTRADA")
                .IsRequired();

            builder.Property(e => e.IdMercadoria)
                .HasColumnName("IDMERCADORIA")
                .IsRequired();

            builder.Property(e => e.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.DataHora)
               .HasColumnName("DATAHORA")
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(e => e.Local)
               .HasColumnName("LOCAL")
               .IsRequired();

            builder.HasOne(e => e.Mercadoria)
                .WithMany(m => m.Entradas)
                .HasForeignKey(e => e.IdMercadoria);
        }
    }
}

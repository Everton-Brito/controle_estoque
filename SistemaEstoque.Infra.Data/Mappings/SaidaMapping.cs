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
    public class SaidaMapping : IEntityTypeConfiguration<Saida>
    {
        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.ToTable("SAIDA");

            builder.HasKey(s => s.IdSaida);

            builder.Property(s => s.IdSaida)
                .HasColumnName("IDSAIDA")
                .IsRequired();

            builder.Property(s => s.IdMercadoria)
                .HasColumnName("IDMERCADORIA")
                .IsRequired();

            builder.Property(s => s.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(s => s.DataHora)
               .HasColumnName("DATAHORA")
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(s => s.Local)
               .HasColumnName("LOCAL")
               .IsRequired();

            builder.HasOne(s => s.Mercadoria)
                .WithMany(m => m.Saidas)
                .HasForeignKey(s => s.IdMercadoria);
        }
    }
}

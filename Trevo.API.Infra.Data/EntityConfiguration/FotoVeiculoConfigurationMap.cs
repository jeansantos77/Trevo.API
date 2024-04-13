using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class FotoVeiculoConfigurationMap : IEntityTypeConfiguration<FotoVeiculo>
    {
        public void Configure(EntityTypeBuilder<FotoVeiculo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                   .HasMaxLength(100);

            builder.Property(c => c.Caminho)
                   .HasMaxLength(100);

            builder.Property(c => c.Nome)
                    .HasMaxLength(30);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class CategoriaVeiculoConfigurationMap : IEntityTypeConfiguration<CategoriaVeiculo>
    {
        public void Configure(EntityTypeBuilder<CategoriaVeiculo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                   .HasMaxLength(100);
        }
    }
}

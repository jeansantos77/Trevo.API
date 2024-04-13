using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class VeiculoConfigurationMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Placa)
                   .HasMaxLength(7);

            builder.Property(c => c.Renavam)
                   .HasMaxLength(11);

            builder.Property(c => c.NumeroMotor)
                   .HasMaxLength(12);

            builder.Property(c => c.Chassi)
                   .HasMaxLength(20);

            builder.Property(c => c.CodigoFipe)
                .HasMaxLength(7);

        }
    }
}

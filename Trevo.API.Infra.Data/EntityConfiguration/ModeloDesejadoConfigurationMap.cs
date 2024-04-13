using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class ModeloDesejadoConfigurationMap : IEntityTypeConfiguration<ModeloDesejado>
    {
        public void Configure(EntityTypeBuilder<ModeloDesejado> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => new { c.ClienteId, c.ModeloId, c.VersaoId, c.CorId }).IsUnique();

            builder.Property(c => c.CriadoPor)
                   .HasMaxLength(30);

            builder.Property(c => c.AtualizadoPor)
                    .HasMaxLength(30);
        }
    }
}

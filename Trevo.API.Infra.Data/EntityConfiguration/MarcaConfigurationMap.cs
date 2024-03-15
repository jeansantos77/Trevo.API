using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class MarcaConfigurationMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                   .HasMaxLength(100);

            builder.Property(c => c.CriadoPor)
                   .HasMaxLength(30);

            builder.Property(c => c.AtualizadoPor)
                   .HasMaxLength(30);
        }
    }
}

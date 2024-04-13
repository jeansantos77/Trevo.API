using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class CambioConfigurationMap : IEntityTypeConfiguration<Cambio>
    {
        public void Configure(EntityTypeBuilder<Cambio> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                   .HasMaxLength(100);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class CidadeConfigurationMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasMaxLength(100);

        }
    }
}

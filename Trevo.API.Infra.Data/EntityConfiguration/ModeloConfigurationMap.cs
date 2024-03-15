using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class ModeloConfigurationMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                   .HasMaxLength(100);

            builder.HasOne(c => c.Marca)
               .WithMany()
               .HasForeignKey(c => c.MarcaId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CriadoPor)
                   .HasMaxLength(30);

            builder.Property(c => c.AtualizadoPor)
                    .HasMaxLength(30);
        }
    }
}

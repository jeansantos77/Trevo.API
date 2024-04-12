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

            builder.HasOne(c => c.Marca)
               .WithMany()
               .HasForeignKey(c => c.MarcaId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Modelo)
               .WithMany()
               .HasForeignKey(c => c.ModeloId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Cor)
               .WithMany()
               .HasForeignKey(c => c.CorId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => new { c.MarcaId, c.ModeloId, c.CorId }).IsUnique();

            builder.Property(c => c.CriadoPor)
                   .HasMaxLength(30);

            builder.Property(c => c.AtualizadoPor)
                    .HasMaxLength(30);
        }
    }
}

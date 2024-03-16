using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class UsuarioConfigurationMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .HasMaxLength(100);

            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Login)
                   .HasMaxLength(30);

            builder.HasIndex(c => c.Login).IsUnique();

            builder.Property(c => c.Senha)
                   .HasMaxLength(250);

            builder.Property(c => c.CriadoPor)
                   .HasMaxLength(30);

            builder.Property(c => c.AtualizadoPor)
                    .HasMaxLength(30);
        }
    }
}

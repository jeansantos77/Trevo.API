using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class ClienteConfigurationMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .HasMaxLength(100);

            builder.Property(c => c.Telefone)
                   .HasMaxLength(50);

            builder.Property(c => c.Cpf)
                   .HasMaxLength(11);

            builder.Property(c => c.Cep)
                .HasMaxLength(8);

            builder.Property(c => c.Logradouro)
                .HasMaxLength(50);

            builder.Property(c => c.Numero)
                .HasMaxLength(10);

            builder.Property(c => c.Bairro)
                .HasMaxLength(50);

            builder.Property(c => c.Complemento)
                .HasMaxLength(50);

            builder.HasMany(b => b.ModelosDesejados) 
               .WithOne(e => e.Cliente)    
               .HasForeignKey(e => e.ClienteId) 
               .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}

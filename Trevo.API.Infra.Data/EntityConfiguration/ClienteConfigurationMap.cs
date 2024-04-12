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

            builder.Property(c => c.Obs)
                .HasMaxLength(500);

            builder.HasOne(c => c.Cidade)
               .WithMany()
               .HasForeignKey(c => c.CidadeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.FormaPagamento)
               .WithMany()
               .HasForeignKey(c => c.FormaPagamentoId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CriadoPor)
                   .HasMaxLength(30);

            builder.Property(c => c.AtualizadoPor)
                    .HasMaxLength(30);

        }
    }
}

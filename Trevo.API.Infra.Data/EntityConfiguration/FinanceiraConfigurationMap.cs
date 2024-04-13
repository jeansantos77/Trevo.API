﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Infra.Data.EntityConfiguration
{
    public class FinanceiraConfigurationMap : IEntityTypeConfiguration<Financeira>
    {
        public void Configure(EntityTypeBuilder<Financeira> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .HasMaxLength(100);

            builder.Property(c => c.Telefone)
                   .HasMaxLength(50);

            builder.Property(c => c.Cnpj)
                   .HasMaxLength(14);

            builder.Property(c => c.Contato)
                   .HasMaxLength(50);

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

        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Trevo.API.Infra.Data.Context;

#nullable disable

namespace Trevo.API.Infra.Data.Migrations
{
    [DbContext(typeof(TrevoContext))]
    partial class TrevoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Trevo.API.Domain.Entities.Acessorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Acessorios");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.CategoriaDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("CategoriasDespesas");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.CategoriaVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("CategoriasVeiculo");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Combustivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Combustiveis");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Cor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Cores");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<int>("CidadeId")
                        .HasColumnType("integer");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("PaisId")
                        .HasColumnType("integer");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.FormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("FormasPagamento");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.SituacaoVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("SituacoesVeiculo");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.TipoDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("TiposDespesa");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AtualizadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Cidade", b =>
                {
                    b.HasOne("Trevo.API.Domain.Entities.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Empresa", b =>
                {
                    b.HasOne("Trevo.API.Domain.Entities.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Estado", b =>
                {
                    b.HasOne("Trevo.API.Domain.Entities.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Trevo.API.Domain.Entities.Modelo", b =>
                {
                    b.HasOne("Trevo.API.Domain.Entities.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Marca");
                });
#pragma warning restore 612, 618
        }
    }
}

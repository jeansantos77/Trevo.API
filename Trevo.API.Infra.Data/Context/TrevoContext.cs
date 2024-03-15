﻿using Microsoft.EntityFrameworkCore;
using Trevo.API.Domain.Entities;
using Trevo.API.Infra.Data.EntityConfiguration;

namespace Trevo.API.Infra.Data.Context
{
    public class TrevoContext : DbContext
    {
        public TrevoContext(DbContextOptions<TrevoContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<TipoDespesa> TiposDespesa { get; set; }
        public DbSet<CategoriaDespesa> CategoriasDespesas { get; set; }
        public DbSet<CategoriaVeiculo> CategoriasVeiculo { get; set; }
        public DbSet<Combustivel> Combustiveis { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Acessorio> Acessorios { get; set; }
        public DbSet<SituacaoVeiculo> SituacoesVeiculo { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfigurationMap());
            modelBuilder.ApplyConfiguration(new CidadeConfigurationMap());
            modelBuilder.ApplyConfiguration(new EstadoConfigurationMap());
            modelBuilder.ApplyConfiguration(new PaisConfigurationMap());
            modelBuilder.ApplyConfiguration(new EmpresaConfigurationMap());

            modelBuilder.ApplyConfiguration(new MarcaConfigurationMap());
            modelBuilder.ApplyConfiguration(new ModeloConfigurationMap());
            modelBuilder.ApplyConfiguration(new TipoDespesaConfigurationMap());
            modelBuilder.ApplyConfiguration(new CategoriaDespesaConfigurationMap());
            modelBuilder.ApplyConfiguration(new CombustivelConfigurationMap());
            modelBuilder.ApplyConfiguration(new CorConfigurationMap());
            modelBuilder.ApplyConfiguration(new CategoriaVeiculoConfigurationMap());
            modelBuilder.ApplyConfiguration(new AcessorioConfigurationMap());
            modelBuilder.ApplyConfiguration(new SituacaoVeiculoConfigurationMap());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfigurationMap());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            var currentTime = DateTime.UtcNow;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property("CriadoEm").CurrentValue = currentTime;
                }

                entity.Property("AtualizadoEm").CurrentValue = currentTime;
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}

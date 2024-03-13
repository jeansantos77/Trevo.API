using Microsoft.EntityFrameworkCore;
using Trevo.API.Domain.Entities;
using Trevo.API.Infra.Data.EntityConfiguration;

namespace Price.API.Infra.Data.Context
{
    public class TrevoContext : DbContext
    {
        public TrevoContext(DbContextOptions<TrevoContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfigurationMap());
            modelBuilder.ApplyConfiguration(new CidadeConfigurationMap());
            modelBuilder.ApplyConfiguration(new EstadoConfigurationMap());
            modelBuilder.ApplyConfiguration(new PaisConfigurationMap());
            modelBuilder.ApplyConfiguration(new EmpresaConfigurationMap());

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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Price.API.Infra.Data.Context
{
    public class TrevoContextFactory : IDesignTimeDbContextFactory<TrevoContext>
    {
        public TrevoContext CreateDbContext(string[] args)
        {
            return CreateDbContext("DefaultConnection");
        }

        public TrevoContext CreateDbContext(string connectionStringName)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TrevoContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(connectionStringName));

            return new TrevoContext(optionsBuilder.Options);
        }
    }
}

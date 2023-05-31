using ControleFluxoCaixa.DOMAIN.Map;
using ControleFluxoCaixa.DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ControleFluxoCaixa.INFRA.Repositories.Base
{
    public class FluxoContext : DbContext
    {
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        private readonly IConfiguration _configuration;

        public FluxoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("ControleFluxoCaixaConnectionString");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging()
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar configurações
            modelBuilder.ApplyConfiguration(new MapLancamento());
            modelBuilder.ApplyConfiguration(new MapRelatorio());
        }
    }
}

using ControleFluxoCaixa.CQRS.COMANDS;
using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos;
using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AdicionarLancamentos;
using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AlterarLancamentos;
using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.DeletarLancamentos;
using ControleFluxoCaixa.CQRS.QUERIES.Lancamentos.ConsolidadoDiario;
using ControleFluxoCaixa.CQRS.QUERIES.Lancamentos.ListarLancamentos;
using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.INFRA.Repositories;
using ControleFluxoCaixa.INFRA.Repositories.Base;
using ControleFluxoCaixa.INFRA.Transactions;
using MediatR;
using System.Reflection;

namespace ControleFluxoCaixa.API
{
    public static class Setup
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(AdicionarLancamentoRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AlterarLancamentoRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(RemoverLancamentoResquest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ListarLancamentoRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ConsolidadoDiarioRequest).GetTypeInfo().Assembly);
            

        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Fluxo.json");
            services.AddSingleton<JsonFileService>(new JsonFileService(path));

 
            services.AddSingleton<LancamentoStore>();

            services.AddSingleton<LancamentoStore, LancamentoStore>();

           
            services.AddScoped<FluxoContext, FluxoContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IRepositoryRelatorio, RepositoryRelatorio>();

            services.AddTransient<IRepositoryLancamento, RepositoryLancamento>();

            services.AddTransient<IRepositoryConsolidado, RepositoryConsolidado>();
        }
    }
}

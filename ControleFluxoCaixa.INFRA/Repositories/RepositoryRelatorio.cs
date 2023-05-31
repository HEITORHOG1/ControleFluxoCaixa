using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using ControleFluxoCaixa.INFRA.Repositories.Base;

namespace ControleFluxoCaixa.INFRA.Repositories
{
    public class RepositoryRelatorio : RepositoryBase<Relatorio, Guid>, IRepositoryRelatorio
    {
        private readonly FluxoContext _context;
        public RepositoryRelatorio(FluxoContext context) : base(context)
        {
            _context = context;
        }
    }
}



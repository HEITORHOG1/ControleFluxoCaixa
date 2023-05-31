using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using ControleFluxoCaixa.INFRA.Repositories.Base;

namespace ControleFluxoCaixa.INFRA.Repositories
{
    public class RepositoryConsolidado : RepositoryBase<Relatorio, Guid>, IRepositoryConsolidado
    {
        private readonly FluxoContext _context;
        public RepositoryConsolidado(FluxoContext context) : base(context)
        {
            _context = context;
        }
    }
}

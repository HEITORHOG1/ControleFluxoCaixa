using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using ControleFluxoCaixa.INFRA.Repositories.Base;

namespace ControleFluxoCaixa.INFRA.Repositories
{
    public class RepositoryLancamento : RepositoryBase<Lancamento, Guid>, IRepositoryLancamento
    {
        private readonly FluxoContext _context;
        public RepositoryLancamento(FluxoContext context) : base(context)
        {
            _context = context;
        }
    }
}

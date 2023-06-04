using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using ControleFluxoCaixa.INFRA.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFluxoCaixa.INFRA.Repositories
{
    public class LancamentoRepositorySimulado : RepositoryBase<Lancamento, Guid>, IRepositoryLancamento
    {

        private readonly FluxoContext _context;
        public LancamentoRepositorySimulado(FluxoContext context) : base(context)
        {
            _context = context;
        }
    }
}
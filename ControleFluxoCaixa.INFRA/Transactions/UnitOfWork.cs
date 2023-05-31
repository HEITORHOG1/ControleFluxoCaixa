using ControleFluxoCaixa.INFRA.Repositories.Base;

namespace ControleFluxoCaixa.INFRA.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FluxoContext _context;

        public UnitOfWork(FluxoContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

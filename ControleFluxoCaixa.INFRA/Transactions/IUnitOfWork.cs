namespace ControleFluxoCaixa.INFRA.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}

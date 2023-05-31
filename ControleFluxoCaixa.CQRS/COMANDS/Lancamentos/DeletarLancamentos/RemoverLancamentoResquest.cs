using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;

namespace ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.DeletarLancamentos
{
    public class RemoverLancamentoResquest : IRequest<Response>
    {
        public RemoverLancamentoResquest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

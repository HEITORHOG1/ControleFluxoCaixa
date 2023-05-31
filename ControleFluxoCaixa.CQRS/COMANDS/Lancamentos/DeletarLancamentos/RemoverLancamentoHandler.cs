using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;
using prmToolkit.NotificationPattern;
using Response = ControleFluxoCaixa.DOMAIN.Model.Response;

namespace ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.DeletarLancamentos
{
    public class RemoverLancamentoHandler : Notifiable, IRequestHandler<RemoverLancamentoResquest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryLancamento _repositoryLancamento;

        public RemoverLancamentoHandler(IMediator mediator, IRepositoryLancamento repositoryLancamento)
        {
            _mediator = mediator;
            _repositoryLancamento = repositoryLancamento;
        }

        public async Task<Response> Handle(RemoverLancamentoResquest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("RemoverLancamentoResquest", "");
                return new Response(this);
            }

            Lancamento lancamento = _repositoryLancamento.ObterPorId(request.Id);

            if (lancamento == null)
            {
                AddNotification("RemoverLancamentoResquest", "");
                return new Response(this);
            }

            _repositoryLancamento.Remover(lancamento);

            var result = new { Id = lancamento.Id };

            //Cria objeto de resposta
            var response = new Response(this, result);

            ////Retorna o resultado
            return await Task.FromResult(response);
        }
    }
}

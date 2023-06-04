using ControleFluxoCaixa.CQRS.Validacao;
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
            // Instancia o validador
            var validator = new RemoverLancamentoValidator();

            // Valida a requisição
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // Se não passou na validação, adiciona as falhas como notificações
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    AddNotification(error.PropertyName, error.ErrorMessage);
                }

                return new Response(this);
            }

            Lancamento lancamento = _repositoryLancamento.ObterPorId(request.Id);

            _repositoryLancamento.Remover(lancamento);

            var result = new { Id = lancamento.Id };

            //Cria objeto de resposta
            var response = new Response(this, result);

            ////Retorna o resultado
            return await Task.FromResult(response);
        }
    }
}

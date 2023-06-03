using ControleFluxoCaixa.CQRS.Validacao;
using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;
using prmToolkit.NotificationPattern;
using Response = ControleFluxoCaixa.DOMAIN.Model.Response;

namespace ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AdicionarLancamentos
{
    public class AdicionarLancamentoHandler : Notifiable, IRequestHandler<AdicionarLancamentoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryLancamento _repositoryLancamento;

        public AdicionarLancamentoHandler(IMediator mediator, IRepositoryLancamento repositoryLancamento)
        {
            _mediator = mediator;
            _repositoryLancamento = repositoryLancamento;
        }

        public async Task<Response> Handle(AdicionarLancamentoRequest request, CancellationToken cancellationToken)
        {
            // Instancia o validador
            var validator = new AdicionarLancamentoValidator();

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
            Lancamento lancamento = new(request.Data, request.descrição, request.Valor,request.Tipo);

            if (IsInvalid())
            {
                return new Response(this);
            }
            lancamento = _repositoryLancamento.Adicionar(lancamento);

            var result = new {
                Data = lancamento.Data, 
                Descricao = lancamento.Descricao,
                Valor = lancamento.Valor,
                Tipo = lancamento.Tipo
            };

            var response = new Response(this, result);

            return await Task.FromResult(response);
        }
    }
}

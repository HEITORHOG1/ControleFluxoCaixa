using ControleFluxoCaixa.DOMAIN.Interfaces;
using MediatR;
using prmToolkit.NotificationPattern;
using ControleFluxoCaixa.DOMAIN.Model;
using Response = ControleFluxoCaixa.DOMAIN.Model.Response;
using ControleFluxoCaixa.CQRS.Validacao;

namespace ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AlterarLancamentos
{
    public class AlterarLancamentoHandler : Notifiable, IRequestHandler<AlterarLancamentoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryLancamento _repositoryLancamento;

        public AlterarLancamentoHandler(IMediator mediator, IRepositoryLancamento repositoryLancamento)
        {
            _mediator = mediator;
            _repositoryLancamento = repositoryLancamento;
        }

        public async Task<Response> Handle(AlterarLancamentoRequest request, CancellationToken cancellationToken)
        {
            // Instancia o validador
            var validator = new AlterarLancamentoValidator();

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

            Lancamento lancamento = new Lancamento(request.Data,request.Descricao,request.Valor, request.Tipo);

            lancamento.AlterarLancamento(request.Id, request.Data, request.Descricao, request.Valor);

            var retornoExist = _repositoryLancamento.Listar().Where(x => x.Id == request.Id);

            lancamento = _repositoryLancamento.Editar(lancamento);

            var result = new 
            { 
                Id = lancamento.Id,
                Data = lancamento.Data,
                Descricao = lancamento.Descricao,   
                Valor = lancamento.Valor,
            };

            var response = new Response(this, result);

            return await Task.FromResult(response);
        }
    }
}

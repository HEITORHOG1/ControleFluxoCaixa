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
            //Validar se o requeste veio preenchido
            if (request == null)
            {
                AddNotification("Lancamento", "Lancamento não pode estar em branco... Preencha um Lancamento");
                return new Response(this);
            }
            if (request.Valor == decimal.MinValue)
            {
                AddNotification("Valor", "Valor não pode estar em branco... Preencha um Valor");
                return new Response(this);
            }
            if (request.Tipo == null)
            {
                AddNotification("Tipo", "Tipo não pode estar em branco... Preencha um Tipo");
                return new Response(this);
            }
            if (request.descrição == null)
            {
                AddNotification("Descricao", "Descricao não pode estar em branco... Preencha uma Descricao");
                return new Response(this);
            }
            if (request.Data == null)
            {
                AddNotification("Data", "Data não pode estar em branco... Preencha uma Data");
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

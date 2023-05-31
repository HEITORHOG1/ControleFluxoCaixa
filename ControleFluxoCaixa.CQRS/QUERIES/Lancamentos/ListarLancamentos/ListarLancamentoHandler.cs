using ControleFluxoCaixa.DOMAIN.Interfaces;
using MediatR;
using prmToolkit.NotificationPattern;
using Response = ControleFluxoCaixa.DOMAIN.Model.Response;

namespace ControleFluxoCaixa.CQRS.QUERIES.Lancamentos.ListarLancamentos
{
    public class ListarLancamentoHandler : Notifiable, IRequestHandler<ListarLancamentoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryLancamento _repositoryLancamento;

        public ListarLancamentoHandler(IMediator mediator, IRepositoryLancamento repositoryLancamento)
        {
            _mediator = mediator;
            _repositoryLancamento = repositoryLancamento;
        }

        public async Task<Response> Handle(ListarLancamentoRequest request, CancellationToken cancellationToken)
        {
            // Valida se o objeto request está nulo
            if (request == null)
            {
                AddNotification("ListarLancamentoRequest", "Erro ao listar Lancamentos");
                return new Response(this);
            }

            var lancamentoCollection = _repositoryLancamento.Listar().ToList();
            // Cria uma nova lista mapeando os lançamentos para conter o tipo como uma string
            var lancamentoList = lancamentoCollection.Select(l => new
            {
                l.Id,
                l.Data,
                l.Descricao,
                l.Valor,
                Tipo = l.TipoString
            }).ToList();

            // Cria objeto de resposta
            var response = new Response(this, lancamentoCollection);

            // Retorna o resultado
            return await Task.FromResult(response);
        }

    }
}


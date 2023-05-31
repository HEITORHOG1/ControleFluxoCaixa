using ControleFluxoCaixa.DOMAIN.Interfaces;
using MediatR;
using prmToolkit.NotificationPattern;
using ControleFluxoCaixa.DOMAIN.Model;
using Response = ControleFluxoCaixa.DOMAIN.Model.Response;

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
            if (request == null)
            {
                AddNotification("AlterarLancamentoRequest", "request");
                return new Response(this);
            }

            Lancamento lancamento = new Lancamento(request.Data,request.Descricao,request.Valor, request.Tipo);

            lancamento.AlterarLancamento(request.Id, request.Data, request.Descricao, request.Valor);

            var retornoExist = _repositoryLancamento.Listar().Where(x => x.Id == request.Id);
            if (!retornoExist.Any())
            {
                AddNotification("AlterarLancamentoRequest", "Lancamento não encontrado");
                return new Response(this);
            }

            if (lancamento == null)
            {
                AddNotification("AlterarLancamentoRequest", "Lancamento == null");
                return new Response(this);
            }

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

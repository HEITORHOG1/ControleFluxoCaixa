using ControleFluxoCaixa.CQRS.QUERIES.Lancamentos.ConsolidadoDiario;
using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using Response = ControleFluxoCaixa.DOMAIN.Model.Response;

namespace ControleFluxoCaixa.CQRS.QUERIES.Consolidados.ConsolidadoDiario
{
    public class ConsolidadoDiarioHandler : Notifiable, IRequestHandler<ConsolidadoDiarioRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryConsolidado _repositoryConsolidado;
        private readonly IRepositoryLancamento _repositoryLancamento;
        public ConsolidadoDiarioHandler(IMediator mediator, IRepositoryConsolidado repositoryConsolidado, IRepositoryLancamento repositoryLancamento)
        {
            _mediator = mediator;
            _repositoryConsolidado = repositoryConsolidado;
            _repositoryLancamento = repositoryLancamento;   
        }

        public async Task<Response> Handle(ConsolidadoDiarioRequest request, CancellationToken cancellationToken)
        {
            // Valida se o objeto request está nulo
            if (request == null)
            {
                AddNotification("ConsolidadoDiarioRequest", "Erro ao obter consolidado diário");
                return new Response(this);
            }

            var data = request.Data.Date;

            var Consolidados = await _repositoryLancamento.Listar()
                .Where(l => l.Data.Date == data)
                .ToListAsync();

            decimal totalCreditos = Consolidados
                .Where(l => l.Tipo == TipoLancamento.Credito)
                .Sum(l => l.Valor);

            decimal totalDebitos = Consolidados
                .Where(l => l.Tipo == TipoLancamento.Debito)
                .Sum(l => l.Valor);

            decimal saldoAtual = totalCreditos + totalDebitos;

            var relatorio = new Relatorio
            {
                TotalCreditos = totalCreditos,
                TotalDebitos = totalDebitos,
                SaldoAtual = saldoAtual,
                Lancamentos = Consolidados,
            };

            // Cria objeto de resposta
            var response = new Response(this, relatorio);

            // Retorna o resultado
            return response;
        }


    }
}

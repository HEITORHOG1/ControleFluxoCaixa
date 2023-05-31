using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;

namespace ControleFluxoCaixa.CQRS.QUERIES.Lancamentos.ConsolidadoDiario
{
    public  class ConsolidadoDiarioRequest : IRequest<Response>
    {
        public ConsolidadoDiarioRequest(DateTime data)
        {
            Data = data;
        }

        public DateTime Data { get; set; }
    }
}

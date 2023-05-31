using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;

namespace ControleFluxoCaixa.CQRS.QUERIES.Lancamentos.ListarLancamentos
{
    public class ListarLancamentoRequest : IRequest<Response>
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
    }
}

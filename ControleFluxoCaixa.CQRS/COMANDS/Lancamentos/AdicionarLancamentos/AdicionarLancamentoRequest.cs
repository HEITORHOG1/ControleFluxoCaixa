using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;

namespace ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AdicionarLancamentos
{
    public class AdicionarLancamentoRequest : IRequest<Response>
    {
        public DateTime Data { get; set; }
        public string? descrição { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}

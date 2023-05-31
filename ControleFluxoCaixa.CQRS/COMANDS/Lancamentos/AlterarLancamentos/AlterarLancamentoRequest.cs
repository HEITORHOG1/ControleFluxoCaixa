using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;

namespace ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AlterarLancamentos
{
    public class AlterarLancamentoRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}

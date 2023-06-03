using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFluxoCaixa.DOMAIN.Model
{
    public class LancamentoSimulacao
    {
        public string TipoString => Tipo == TipoLancamentoSimulacao.Credito ? "Crédito" : "Débito";
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamentoSimulacao Tipo { get; set; }
        public Guid Id { get; set; }

        public enum TipoLancamentoSimulacao
        {
            Credito,
            Debito
        }
    }
}

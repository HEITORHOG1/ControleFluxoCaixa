using ControleFluxoCaixa.DOMAIN.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFluxoCaixa.DOMAIN.Model
{
    [Table("Relatorio")]
    public class RelatorioSimulacao : EntityBase
    {
        public RelatorioSimulacao()
        {
            Lancamentos = new List<LancamentoSimulacao>();
        }
        public decimal SaldoAtual { get; set; }
        public decimal TotalCreditos { get; set; }
        public decimal TotalDebitos { get; set; }

        [NotMapped]
        public List<LancamentoSimulacao> Lancamentos { get; set; }
    }

}

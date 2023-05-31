using ControleFluxoCaixa.DOMAIN.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFluxoCaixa.DOMAIN.Model
{
    [Table("Relatorio")]
    public class Relatorio: EntityBase
    {
        public Relatorio()
        {
            Lancamentos = new List<Lancamento>();
        }
        public decimal SaldoAtual { get; set; }
        public decimal TotalCreditos { get; set; }
        public decimal TotalDebitos { get; set; }

        [NotMapped]
        public List<Lancamento> Lancamentos { get; set; }
    }

}

using ControleFluxoCaixa.DOMAIN.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFluxoCaixa.DOMAIN.Model
{
    [Table("Lancamento")]
    public class Lancamento: EntityBase
    {
        public string TipoString => Tipo == TipoLancamento.Credito ? "Crédito" : "Débito";
        public Lancamento(DateTime data, string descricao, decimal valor, TipoLancamento tipo)
        {
            Data = data;
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
        }

        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }

        public void AlterarLancamento(Guid id, DateTime data, string descricao, decimal valor)
        {
            Id = id;
            Data = data;
            Descricao = descricao;
            Valor = valor;  
        }
    }

    public enum TipoLancamento
    {
        Credito,
        Debito
    }
}

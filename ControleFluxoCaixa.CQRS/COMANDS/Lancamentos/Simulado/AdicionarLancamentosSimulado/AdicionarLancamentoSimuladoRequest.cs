using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.Simulado.AdicionarLancamentosSimulado
    {
        public class AdicionarLancamentoSimuladoRequest : IRequest
        {
            public LancamentoSimulacao? LancamentoSimulacao { get; set; }
           
        }
    }



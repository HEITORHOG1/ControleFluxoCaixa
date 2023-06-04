using ControleFluxoCaixa.DOMAIN.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFluxoCaixa.CQRS.Validacao
{
    public class LancamentoSimulacaoValidator : AbstractValidator<LancamentoSimulacao>
    {
        public LancamentoSimulacaoValidator()
        {
            RuleFor(l => l.Data)
                .NotEmpty().WithMessage("Data não pode estar em branco.");

            RuleFor(l => l.Descricao)
                .NotEmpty().WithMessage("Descrição não pode estar em branco.");

            RuleFor(l => l.Valor)
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero.");

            RuleFor(l => l.Tipo)
                .IsInEnum().WithMessage("Tipo inválido.");
        }
    }
}

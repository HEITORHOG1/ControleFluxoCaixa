using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.DeletarLancamentos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFluxoCaixa.CQRS.Validacao
{
    public class RemoverLancamentoValidator : AbstractValidator<RemoverLancamentoResquest>
    {
        public RemoverLancamentoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id não pode estar em branco... Preencha um Id");
        }
    }
}

﻿using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AdicionarLancamentos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFluxoCaixa.CQRS.Validacao
{
    public class AdicionarLancamentoValidator : AbstractValidator<AdicionarLancamentoRequest>
    {
        public AdicionarLancamentoValidator()
        {
            RuleFor(x => x.Data)
                .NotEmpty().WithMessage("Data não pode estar em branco... Preencha uma Data");

            RuleFor(x => x.descrição)
                .NotEmpty().WithMessage("Descricao não pode estar em branco... Preencha uma Descricao");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("Valor não pode estar em branco... Preencha um Valor")
                .GreaterThan(0).WithMessage("Valor deve ser maior que 0");

            RuleFor(x => x.Tipo)
                .NotNull().WithMessage("Tipo não pode estar em branco... Preencha um Tipo");
        }
    }
}

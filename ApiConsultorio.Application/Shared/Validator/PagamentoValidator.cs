using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Shared.Validator
{
    public class PagamentoCreateValidator : AbstractValidator<CreatePagamentoRequest>
    {
        public PagamentoCreateValidator()
        {
            RuleFor(x => x.Ano).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Mes).NotEmpty();
            RuleFor(x => x.Valor).NotEmpty();
        }
    }
}

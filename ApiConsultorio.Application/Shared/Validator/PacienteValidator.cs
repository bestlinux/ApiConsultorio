using ApiConsultorio.Application.UseCases.Categorys.CreateCategory;
using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Shared.Validator
{
    public class PacienteCreateValidator : AbstractValidator<CreatePacienteRequest>
    {
        public PacienteCreateValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.CPF).NotEmpty();
            RuleFor(x => x.Telefone).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.DataNascimento).NotEmpty();
            RuleFor(x => x.Sexo).NotEmpty();
            RuleFor(x => x.TipoPagamento).NotEmpty();
            RuleFor(x => x.Ativo).NotEmpty();
        }
    }

    public class PacienteUpdateValidator : AbstractValidator<UpdatePacienteRequest>
    {
        public PacienteUpdateValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.CPF).NotEmpty();
            RuleFor(x => x.Telefone).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Nascimento).NotEmpty();
            RuleFor(x => x.Sexo).NotEmpty();
            RuleFor(x => x.TipoPagamento).NotEmpty();
            RuleFor(x => x.Ativo).NotEmpty();
        }
    }
}

using ApiConsultorio.Application.UseCases.Categorys.CreateCategory;
using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Shared.Validator
{
    public class PacienteValidator : AbstractValidator<CreatePacienteRequest>
    {
        public PacienteValidator()
        {
            RuleFor(x => x.Paciente.Nome).NotEmpty();
            RuleFor(x => x.Paciente.CPF).NotEmpty();
            RuleFor(x => x.Paciente.Telefone).NotEmpty();
            RuleFor(x => x.Paciente.Email).NotEmpty();
        }
    }
}

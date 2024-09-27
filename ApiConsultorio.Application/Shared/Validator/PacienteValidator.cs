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
        }
    }

    public class PacienteUpdateValidator : AbstractValidator<UpdatePacienteRequest>
    {
        public PacienteUpdateValidator()
        {
        }
    }
}

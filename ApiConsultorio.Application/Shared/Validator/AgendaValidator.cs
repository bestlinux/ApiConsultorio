using ApiConsultorio.Application.UseCases.Agendas.CreateAgenda;
using ApiConsultorio.Application.UseCases.Agendas.UpdateAgenda;
using ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Shared.Validator
{
    public class AgendaCreateValidator : AbstractValidator<CreateAgendaRequest>
    {
        public AgendaCreateValidator()
        {
            RuleFor(x => x.PacienteId).NotEmpty();
            RuleFor(x => x.TipoConsulta).NotEmpty();
            RuleFor(x => x.InicioSessao).NotEmpty();
            RuleFor(x => x.FimSessao).NotEmpty();
            RuleFor(x => x.ValorSessao).NotEmpty();
        }
    }
    public class AgendaUpdateValidator : AbstractValidator<UpdateAgendaRequest>
    {
        public AgendaUpdateValidator()
        {
            RuleFor(x => x.PacienteId).NotEmpty();
            RuleFor(x => x.TipoConsulta).NotEmpty();
            RuleFor(x => x.InicioSessao).NotEmpty();
            RuleFor(x => x.FimSessao).NotEmpty();
            RuleFor(x => x.ValorSessao).NotEmpty();
        }
    }
}

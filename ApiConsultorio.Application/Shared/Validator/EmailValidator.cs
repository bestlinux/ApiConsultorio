using ApiConsultorio.Application.UseCases.Agendas.CreateAgenda;
using ApiConsultorio.Application.UseCases.Mail.SendEmailAgenda;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Shared.Validator
{
    public class EmailCreateValidator : AbstractValidator<SendEmailAgendaRequest>
    {
        public EmailCreateValidator()
        {
            RuleFor(x => x.PacienteNome).NotEmpty();
            RuleFor(x => x.PacienteEmail).NotEmpty();
        }
    }
}


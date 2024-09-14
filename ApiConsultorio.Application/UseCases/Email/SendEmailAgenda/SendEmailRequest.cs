using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Mail.SendEmailAgenda
{
    public class SendEmailAgendaRequest : IRequest<bool>
    {
        public string? PacienteNome { get; set; }

        public string? PacienteEmail { get; set; }

        public DateTime? InicioSessao { get; set; }

        public DateTime? FimSessao { get; set; }
    }
}

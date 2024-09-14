using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.DeleteAgendaPacienteByRecorrencia
{
    public sealed record DeleteAgendaPacienteByRecorrenciaRequest(int PacienteID) : IRequest<bool>;

}

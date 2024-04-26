using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Prontuarios.GetAllProntuarioByPaciente
{
    public sealed record GetAllProntuarioByPacienteRequest (int PacienteID) : IRequest<IReadOnlyCollection<GetAllProntuarioByPacienteResponse>>;
}

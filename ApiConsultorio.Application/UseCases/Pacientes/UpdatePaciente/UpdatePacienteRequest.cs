using ApiConsultorio.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente
{
    public sealed record UpdatePacienteRequest (Paciente Paciente) : IRequest<UpdatePacienteResponse>;
}

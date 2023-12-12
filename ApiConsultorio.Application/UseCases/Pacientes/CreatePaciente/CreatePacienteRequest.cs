using ApiConsultorio.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente
{
    public sealed record CreatePacienteRequest (Paciente Paciente) : IRequest<CreatePacienteResponse>;
}

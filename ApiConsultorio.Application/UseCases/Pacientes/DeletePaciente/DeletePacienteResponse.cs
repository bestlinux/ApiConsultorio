using ApiConsultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.DeletePaciente
{
    public sealed record DeletePacienteResponse
    {
        public bool? Success { get; set; }
        public ErrorDto Error { get; set; }
    }
}

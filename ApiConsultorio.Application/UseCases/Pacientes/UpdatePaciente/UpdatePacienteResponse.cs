using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente
{
    public sealed record UpdatePacienteResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}

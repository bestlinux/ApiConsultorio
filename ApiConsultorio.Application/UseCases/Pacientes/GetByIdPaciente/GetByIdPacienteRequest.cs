using ApiConsultorio.Application.UseCases.Pacientes.GetAllPaciente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.GetByIdPaciente
{
    public class GetByIdPacienteRequest : IRequest<GetByIdPacienteResponse>
    {
        public int Id { get; set; }
    }
}

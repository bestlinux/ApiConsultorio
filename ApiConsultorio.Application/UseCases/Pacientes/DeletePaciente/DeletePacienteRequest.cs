using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.DeletePaciente
{
    public class DeletePacienteRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

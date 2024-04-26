using ApiConsultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Prontuarios.GetAllProntuario
{
    public class GetAllProntuarioResponse
    {
        public int Id { get; set; }
        public Paciente? Paciente { get; set; }

        public int? PacienteId { get; set; }

        public string? Pagina { get; set; }

        public string? Conteudo { get; set; }
    }
}

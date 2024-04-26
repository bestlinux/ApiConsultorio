using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Prontuarios.UpdateProntuario
{
    public class UpdateProntuarioResponse
    {
        public int Id { get; set; }
        public int? PacienteId { get; set; }

        public string? Pagina { get; set; }

        public string? Conteudo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Avisos.GetAllAviso
{
    public sealed record GetAllAvisoResponse
    {
        public int? Id { get; set; }
        public int? PacienteId { get; set; }

        public string? PacienteNome { get; set; }

        public int? Categoria { get; set; }

        public int? Status { get; set; }

        public string? Descricao { get; set; }
    }
}

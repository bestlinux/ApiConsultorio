using ApiConsultorio.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
    public class Tarefa : Entity
    {
        public Paciente? Paciente { get; set; }

        public int? PacienteId { get; set; }

        public string? PacienteNome { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Descricao { get; set; }

        public int? Status { get; set; }

    }
}

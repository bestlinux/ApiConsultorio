using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
    public class EmailAgenda
    {
        public string ?PacienteNome { get; set; }

        public string ?PacienteEmail { get; set; }

        public DateTime? InicioSessao { get; set; }

        public DateTime? FimSessao { get; set; }

        public int ?NumeroRecorrencias { get; set; }

        public int ?TipoRecorrencia { get; set; }
    }
}

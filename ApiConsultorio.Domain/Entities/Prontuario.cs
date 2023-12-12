using ApiConsultorio.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
    public class Prontuario : Entity
    {
        public string Paciente { get; set; }

        public string QueixaInicial { get; set; }

        public string SinteseEscuta { get; set; }

        public DateTime DataSessao { get; set; }

    }
}

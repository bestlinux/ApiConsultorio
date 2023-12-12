using ApiConsultorio.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
    public class Calendario : Entity
    {
        public string Nome { get; set; }

        public string Horario { get; set; }

    }
}

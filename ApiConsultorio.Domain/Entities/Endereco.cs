using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
    public class Endereco
    {
        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

    }
}

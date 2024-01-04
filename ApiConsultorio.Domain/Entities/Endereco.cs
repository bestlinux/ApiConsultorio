using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

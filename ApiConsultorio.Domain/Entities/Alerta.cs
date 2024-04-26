using ApiConsultorio.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
    public class Alerta
    {
        public string? Descricao { get; set; }

        //1 - ANIVERSARIO
        //2 - PAGAMENTOS
        public int Categoria { get; set; }
    }
}

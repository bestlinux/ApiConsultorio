using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMes
{
    public class GetAllAlertasByMesAnoResponse
    {
        public string? Descricao { get; set; }

        //1 - ANIVERSARIO
        //2 - PAGAMENTOS
        public int Categoria { get; set; }
    }
}

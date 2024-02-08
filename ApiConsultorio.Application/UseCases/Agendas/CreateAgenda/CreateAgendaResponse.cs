using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.CreateAgenda
{
    public class CreateAgendaResponse
    {
        public int? PacienteId { get; set; }

        //1 - PRIMEIRO ATENDIMENTO
        //2 - CONSULTA ONLINE
        //3 - CONSULTA PRESENCIAL

        public int? TipoConsulta { get; set; }

        //1 - ATENDIMENTO REALIZADO
        //2 - FALTOU 
        //3 - DESMARCADO

        public int? StatusConsulta { get; set; }

        public DateTime InicioSessao { get; set; }

        public DateTime FimSessao { get; set; }

        public double? ValorSessao { get; set; }
    }
}

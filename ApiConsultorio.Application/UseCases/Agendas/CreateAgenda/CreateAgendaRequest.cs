using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.CreateAgenda
{
    public class CreateAgendaRequest : IRequest<CreateAgendaResponse>
    {
        public int? PacienteId { get; set; }

        public string? PacienteNome { get; set; }

        public string? CPFPagador { get; set; }

        public string? CPF { get; set; }

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

        public int TipoRecorrencia { get; set; }

        public int NumeroRecorrencias { get; set; }

        public bool EmailAgendamento { get; set; }
    }
}

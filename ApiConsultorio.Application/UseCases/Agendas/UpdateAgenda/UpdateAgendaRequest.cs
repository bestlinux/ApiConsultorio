using ApiConsultorio.Application.UseCases.Agendas.CreateAgenda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.UpdateAgenda
{
    public class UpdateAgendaRequest : IRequest<UpdateAgendaResponse>
    {
        public int Id { get; set; }
        public int? PacienteId { get; set; }

        public string? PacienteNome { get; set; }

       //<RadzenRadioButtonListItem Text = "Online" Value="1" />
       //<RadzenRadioButtonListItem Text = "Presencial" Value="2" />
       //<RadzenRadioButtonListItem Text = "Primeiro Atendimento" Value="3" />

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

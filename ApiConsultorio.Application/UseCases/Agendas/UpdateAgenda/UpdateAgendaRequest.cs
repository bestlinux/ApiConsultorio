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

        //Id = 1, Nome = "Médico" },
        //Id = 2, Nome = "Terapia" },
        //Id = 3, Nome = "Supervisão" },
        //Id = 4, Nome = "Grupo de Estudos" },
        //Id = 5, Nome = "Clube do livro psicanálise" }
        //Id = 6, Nome = "Clube do livro" },
        //Id = 7, Nome = "Textos de Freud" },
        //Id = 8, Nome = "Confraria" },
        //Id = 9, Nome = "Psicanálise" },
        //Id = 10, Nome = "Francês" },
        //Id = 11, Nome = "Outros" },
        public int? CategoriaAgendamento { get; set; }

        public DateTime InicioSessao { get; set; }

        public DateTime FimSessao { get; set; }

        public double? ValorSessao { get; set; }

        public string? Observacoes { get; set; }
    }
}

using ApiConsultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Interfaces
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        Task DeletaTodosAgendamentosPorTipoConsulta(int TipoConsulta);

        Task DeletaTodosAgendamentosPorRecorrencia(int PacienteId);

        Task DeletaTodosAgendamentosPessoalPorRecorrencia(int CategoriaAgendamento);

        Task<IEnumerable<Agenda>> LocalizaAniversarios(int idPaciente, int tipoConsulta);
    }
}

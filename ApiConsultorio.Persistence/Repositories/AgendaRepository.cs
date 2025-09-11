
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using ApiConsultorio.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiConsultorio.Persistence.Repositories
{
    public class AgendaRepository(AppDbContext context) : Repository<Agenda>(context), IAgendaRepository
    {
        public async Task DeletaTodosAgendamentosPorRecorrencia(int PacienteId)
        {
            _db.Agendas.RemoveRange(_db.Agendas.AsNoTracking()
             .Where(b => b.StatusConsulta == 4 && b.PacienteId == PacienteId));
            await _db.SaveChangesAsync();
        }

        public async Task DeletaTodosAgendamentosPorTipoConsulta(int TipoConsulta)
        {
             _db.Agendas.RemoveRange(_db.Agendas.AsNoTracking()
             .Where(b => b.TipoConsulta == TipoConsulta));
              await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Agenda>> LocalizaAniversarios(int idPaciente, int tipoConsulta)
        {
            return await _db.Agendas.AsNoTracking()
                .Where(b => b.PacienteId == idPaciente && b.TipoConsulta == tipoConsulta)
                .ToListAsync();
        }
    }
}

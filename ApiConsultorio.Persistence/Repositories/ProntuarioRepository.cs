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
    public class ProntuarioRepository : Repository<Prontuario>, IProntuarioRepository
    {
        public ProntuarioRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Prontuario>> LocalizaTodosProntuariosComPaciente(int idPaciente)
        {
            return await _db.Prontuarios.AsNoTracking()
            .Include(b => b.Paciente)
                .Where(b => b.PacienteId == idPaciente)
                .ToListAsync();
        }
    }
}

using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using ApiConsultorio.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Persistence.Repositories
{
    public class PagamentoRepository : Repository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Pagamento>> LocalizaTodosPagamentosComPaciente()
        {
            return await _db.Pagamentos.AsNoTracking()
                .Include(b => b.Paciente)                
                .ToListAsync();
        }

        public async Task<IEnumerable<Pagamento>> LocalizaTodosPagamentosPorPacienteMesAno(int idPaciente, int Mes, int Ano)
        {
            return await _db.Pagamentos.AsNoTracking()
                 .Include(b => b.Paciente)
                 .Where(b => b.PacienteId == idPaciente && b.Mes == Mes && b.Ano == Ano)
                 .ToListAsync();
        }
    }
}

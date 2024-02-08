using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using ApiConsultorio.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Persistence.Repositories
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(AppDbContext context) : base(context) { }
    }
}

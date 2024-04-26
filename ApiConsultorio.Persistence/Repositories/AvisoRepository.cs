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
    public class AvisoRepository : Repository<Aviso>, IAvisoRepository
    {
        public AvisoRepository(AppDbContext context) : base(context) { }
    }
}

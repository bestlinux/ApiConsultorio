using ApiConsultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Interfaces
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        Task<IEnumerable<Pagamento>> LocalizaTodosPagamentosComPaciente();

        Task<IEnumerable<Pagamento>> LocalizaTodosPagamentosPorPacienteMesAno(int idPaciente, int Mes, int Ano);
    }
}

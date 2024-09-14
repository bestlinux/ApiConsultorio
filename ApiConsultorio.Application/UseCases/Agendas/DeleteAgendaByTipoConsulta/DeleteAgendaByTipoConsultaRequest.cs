using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.DeleteAgendaByTipoConsulta
{
    public class DeleteAgendaByTipoConsultaRequest : IRequest<bool>
    {
        public int TipoConsulta { get; set; }
    }
}

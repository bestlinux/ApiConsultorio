using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMes
{
    public sealed record GetAllAlertasByMesAnoRequest(int Mes, int Ano) : IRequest<IReadOnlyCollection<GetAllAlertasByMesAnoResponse>>;
}

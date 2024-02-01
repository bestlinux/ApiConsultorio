using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamento
{
    public sealed record GetAllPagamentoRequest : IRequest<IReadOnlyCollection<GetAllPagamentoResponse>>;
}

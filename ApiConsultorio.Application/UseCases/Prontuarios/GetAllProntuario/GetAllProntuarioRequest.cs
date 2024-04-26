using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamento;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Prontuarios.GetAllProntuario
{
    public sealed record GetAllProntuarioRequest : IRequest<IReadOnlyCollection<GetAllProntuarioResponse>>;
}

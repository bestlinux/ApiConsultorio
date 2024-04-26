using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Avisos.GetAllAviso
{
    public sealed record GetAllAvisoRequest : IRequest<IReadOnlyCollection<GetAllAvisoResponse>>;
}

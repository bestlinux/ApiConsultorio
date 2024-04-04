using ApiConsultorio.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.GetAllAgenda
{
    public sealed record GetAllAgendaRequest() : IRequest<IReadOnlyCollection<GetAllAgendaResponse>>;
   
}

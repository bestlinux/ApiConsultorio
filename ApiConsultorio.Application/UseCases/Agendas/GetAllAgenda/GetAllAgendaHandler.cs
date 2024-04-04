using ApiConsultorio.Application.UseCases.Categorys.GetAllCategory;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.GetAllAgenda
{
    public class GetAllAgendaHandler : IRequestHandler<GetAllAgendaRequest, IReadOnlyCollection<GetAllAgendaResponse>>
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public GetAllAgendaHandler(IAgendaRepository agendaRepository,
        IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<GetAllAgendaResponse>> Handle(GetAllAgendaRequest request, CancellationToken cancellationToken)
        {
            var agendas = await _agendaRepository.GetAllAsync(cancellationToken);

            return agendas.Select(_mapper.Map<GetAllAgendaResponse>).ToList();
        }
    }
}

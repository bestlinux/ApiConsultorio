using ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMes;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamentoByPacienteMesAno;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMesAno
{
    public class GetAllAlertasByMesAnoHandler : IRequestHandler<GetAllAlertasByMesAnoRequest, IReadOnlyCollection<GetAllAlertasByMesAnoResponse>>
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetAllAlertasByMesAnoHandler(IPagamentoRepository pagamentoRepository,
         IPacienteRepository pacienteRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
            _mediator = mediator;
            _pacienteRepository = pacienteRepository;
        }

        public Task<IReadOnlyCollection<GetAllAlertasByMesAnoResponse>> Handle(GetAllAlertasByMesAnoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

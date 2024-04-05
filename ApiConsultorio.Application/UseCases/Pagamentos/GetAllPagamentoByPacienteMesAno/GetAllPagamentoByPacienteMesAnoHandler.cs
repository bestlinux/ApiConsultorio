using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamento;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamentoByPacienteMesAno
{
    public class GetAllPagamentoByPacienteMesAnoHandler : IRequestHandler<GetAllPagamentoByPacienteMesAnoRequest, IReadOnlyCollection<GetAllPagamentoByPacienteMesAnoResponse>>
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetAllPagamentoByPacienteMesAnoHandler(IPagamentoRepository pagamentoRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IReadOnlyCollection<GetAllPagamentoByPacienteMesAnoResponse>> Handle(GetAllPagamentoByPacienteMesAnoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Pagamento>? enumerable = null;
                var pagamentos = enumerable;

                if (request.Mes == -1 || request.Mes == 0)
                    pagamentos = await _pagamentoRepository.LocalizaTodosPagamentosPorPacienteAno(request.PacienteID, request.Ano);
                else
                    pagamentos = await _pagamentoRepository.LocalizaTodosPagamentosPorPacienteMesAno(request.PacienteID, request.Mes, request.Ano);

                return pagamentos.Select(_mapper.Map<GetAllPagamentoByPacienteMesAnoResponse>).ToList();
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao buscar pagamentos por paciente, mes e ano",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

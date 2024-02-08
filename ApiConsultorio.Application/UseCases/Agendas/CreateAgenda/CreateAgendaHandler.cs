using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.CreateAgenda
{
    public class CreateAgendaHandler : IRequestHandler<CreateAgendaRequest, CreateAgendaResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateAgendaHandler(IUnitOfWork unitOfWork,
        IAgendaRepository agendaRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _agendaRepository = agendaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateAgendaResponse> Handle(CreateAgendaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var agenda = _mapper.Map<Agenda>(request);

                await _agendaRepository.AddAsync(agenda);

                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new AgendaActionNotification
                {
                    PacienteId = request.PacienteId,
                    Action = ActionNotification.Created
                }, cancellationToken);

                return _mapper.Map<CreateAgendaResponse>(agenda);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao registrar o agendamento",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

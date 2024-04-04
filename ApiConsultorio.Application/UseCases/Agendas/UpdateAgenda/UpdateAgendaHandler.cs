using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApiConsultorio.Application.UseCases.Agendas.UpdateAgenda
{
    public class UpdateAgendaHandler : IRequestHandler<UpdateAgendaRequest, UpdateAgendaResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAgendaRepository _agendaRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateAgendaHandler(IUnitOfWork unitOfWork,
           IAgendaRepository agendaRepository,
           IPagamentoRepository pagamentoRepository,
           IMapper mapper,
           IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _agendaRepository = agendaRepository;
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<UpdateAgendaResponse> Handle(UpdateAgendaRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var agenda = _mapper.Map<Agenda>(request);

                await _agendaRepository.UpdateAsync(agenda);

                await _unitOfWork.Commit(cancellationToken);

                //Text = "Atendido" Value = "1" />
                //Text = "Faltou" Value = "2" />
                //Text = "Desmarcado" Value = "3" />
                //Text = "Nenhum" Value = "0" />

                if (request.StatusConsulta == 1 || request.StatusConsulta == 2)
                {
                    Pagamento pagamento = new()
                    {
                        //PAGO
                        StatusPagamento = 1,
                        Ano = request.InicioSessao.Year,
                        PacienteId = request.PacienteId,
                        Valor = request.ValorSessao,
                        Mes = request.InicioSessao.Month
                    };
                    await _pagamentoRepository.AddAsync(pagamento);
                    await _unitOfWork.Commit(cancellationToken);
                }

                await _mediator.Publish(new AgendaActionNotification
                {
                    PacienteId = request.PacienteId,
                    Action = ActionNotification.Updated
                }, cancellationToken);

                return _mapper.Map<UpdateAgendaResponse>(agenda);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao atualizar a agenda",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

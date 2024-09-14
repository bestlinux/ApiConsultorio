using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Agendas.DeleteAgenda;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.DeleteAgendaPacienteByRecorrencia
{
    public class DeleteAgendaPacienteByRecorrenciaHandler : IRequestHandler<DeleteAgendaPacienteByRecorrenciaRequest, bool>
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMediator _mediator;

        public DeleteAgendaPacienteByRecorrenciaHandler(IAgendaRepository agendaRepository,
        IMediator mediator)
        {
            _agendaRepository = agendaRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteAgendaPacienteByRecorrenciaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _agendaRepository.DeletaTodosAgendamentosPorRecorrencia(request.PacienteID);

                return true;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao excluir a recorrencia de agenda para o paciente  " + request.PacienteID,
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return false;
            }
        }
    }
}

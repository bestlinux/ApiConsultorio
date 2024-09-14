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

namespace ApiConsultorio.Application.UseCases.Agendas.DeleteAgendaByTipoConsulta
{
    public class DeleteAgendaByTipoConsultaHandler : IRequestHandler<DeleteAgendaByTipoConsultaRequest, bool>
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMediator _mediator;

        public DeleteAgendaByTipoConsultaHandler(IAgendaRepository agendaRepository,
        IMediator mediator)
        {
            _agendaRepository = agendaRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteAgendaByTipoConsultaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _agendaRepository.DeletaTodosAgendamentosPorTipoConsulta(request.TipoConsulta);

                return true;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao excluir a agenda de tipo de consulta " + request.TipoConsulta,
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return false;
            }
        }
    }
}

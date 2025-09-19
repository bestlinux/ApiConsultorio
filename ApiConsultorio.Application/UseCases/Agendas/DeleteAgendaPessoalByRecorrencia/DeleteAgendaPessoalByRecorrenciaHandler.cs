using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Agendas.DeleteAgendaPacienteByRecorrencia;
using ApiConsultorio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.DeleteAgendaPessoalByRecorrencia
{
    public class DeleteAgendaPessoalByRecorrenciaHandler : IRequestHandler<DeleteAgendaPessoalByRecorrenciaRequest, bool>
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMediator _mediator;

        public DeleteAgendaPessoalByRecorrenciaHandler(IAgendaRepository agendaRepository,
        IMediator mediator)
        {
            _agendaRepository = agendaRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteAgendaPessoalByRecorrenciaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _agendaRepository.DeletaTodosAgendamentosPessoalPorRecorrencia(request.CategoriaAgendamento);

                return true;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao excluir a recorrencia de agenda para a categoria  " + request.CategoriaAgendamento,
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return false;
            }
        }
    }
}

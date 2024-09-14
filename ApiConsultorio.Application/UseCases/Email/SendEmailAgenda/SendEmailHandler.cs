using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Agendas.DeleteAgenda;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Mail.SendEmailAgenda
{
    public class SendEmailAgendaHandler : IRequestHandler<SendEmailAgendaRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;

        public SendEmailAgendaHandler(IMapper mapper,
        IMediator mediator,
        IEmailService emailService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _emailService = emailService;
        }

        public async Task<bool> Handle(SendEmailAgendaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var email = _mapper.Map<EmailAgenda>(request);
                await _emailService.EnviarEmailAgenda(email);
                return true;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu ao enviar um email para " + request.PacienteEmail,
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return false;
            }
        }
    }
}

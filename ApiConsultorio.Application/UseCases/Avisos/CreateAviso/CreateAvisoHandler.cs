using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Avisos.GetAllAviso;
using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Avisos.CreateAviso
{
    public class CreateAvisoHandler : IRequestHandler<CreateAvisoRequest, bool>
    {
        private readonly IAvisoRepository _avisoRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAvisoHandler(IAvisoRepository avisoRepository,
        IMediator mediator,
        IUnitOfWork unitOfWork)
        {
            _avisoRepository = avisoRepository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;   
        }
        public async Task<bool> Handle(CreateAvisoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var aviso = new Aviso();

                await _avisoRepository.AddAsync(aviso);

                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new AvisoActionNotification
                {
                    Id = aviso.Id,
                    Action = ActionNotification.Created
                }, cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao criar o aviso",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return false;
            }
        }
    }
}

using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Pacientes.GetByIdPaciente;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.DeletePaciente
{
    public class DeletePacienteHandler : IRequestHandler<DeletePacienteRequest, bool>
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeletePacienteHandler(IPacienteRepository pacienteRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeletePacienteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _pacienteRepository.RemoveAsync(request.Id);

                return true;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao buscar o pacientes de id " + request.Id,
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return false;
            }
        }
    }
}

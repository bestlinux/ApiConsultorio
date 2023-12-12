using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Categorys.CreateCategory;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente
{
    public class CreatePacienteHandler : IRequestHandler<CreatePacienteRequest, CreatePacienteResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreatePacienteHandler(IUnitOfWork unitOfWork,
        IPacienteRepository pacienteRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<CreatePacienteResponse> Handle(CreatePacienteRequest request,
         CancellationToken cancellationToken)
        {
            var paciente = _mapper.Map<Paciente>(request);

            await _pacienteRepository.AddAsync(paciente);

            await _unitOfWork.Commit(cancellationToken);

            await _mediator.Publish(new PacienteActionNotification
            {
                Nome = request.Paciente.Nome,
                Action = ActionNotification.Created
            }, cancellationToken);

            return _mapper.Map<CreatePacienteResponse>(paciente);
        }
      
    }
}

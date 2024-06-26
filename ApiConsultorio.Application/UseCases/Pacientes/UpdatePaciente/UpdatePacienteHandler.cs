﻿using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente
{
    public class UpdatePacienteHandler : IRequestHandler<UpdatePacienteRequest, UpdatePacienteResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdatePacienteHandler(IUnitOfWork unitOfWork,
            IPacienteRepository pacienteRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<UpdatePacienteResponse> Handle(UpdatePacienteRequest request,
           CancellationToken cancellationToken)
        {
            try
            {
                var paciente = _mapper.Map<Paciente>(request);

                await _pacienteRepository.UpdateAsync(paciente);

                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new PacienteActionNotification
                {
                    Nome = request.Nome,
                    Action = ActionNotification.Updated
                }, cancellationToken);

                return _mapper.Map<UpdatePacienteResponse>(paciente);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao atualizar o paciente",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

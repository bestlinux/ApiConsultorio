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
        private readonly IProntuarioRepository _prontuarioRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreatePacienteHandler(IUnitOfWork unitOfWork,
        IPacienteRepository pacienteRepository,
        IProntuarioRepository prontuarioRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _pacienteRepository = pacienteRepository;
            _prontuarioRepository = prontuarioRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<CreatePacienteResponse> Handle(CreatePacienteRequest request,
         CancellationToken cancellationToken)
        {
            try
            {
                var paciente = _mapper.Map<Paciente>(request);

                await _pacienteRepository.AddAsync(paciente);

                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new PacienteActionNotification
                {
                    Nome = request.Nome,
                    Action = ActionNotification.Created
                }, cancellationToken);

                var pronturarioQueixa = new Prontuario
                {
                    Pagina = "Queixa",
                    PacienteId = paciente.Id,
                    Conteudo = String.Empty
                };

                await _prontuarioRepository.AddAsync(pronturarioQueixa);
                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new ProntuarioActionNotification
                {
                    Pagina = "Queixa",
                    Action = ActionNotification.Created
                }, cancellationToken);

                var pronturarioEntrevista = new Prontuario
                {
                    Pagina = "Entrevista",
                    PacienteId = paciente.Id,
                    Conteudo = String.Empty
                };

                await _prontuarioRepository.AddAsync(pronturarioEntrevista);
                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new ProntuarioActionNotification
                {
                    Pagina = "Entrevista",
                    Action = ActionNotification.Created
                }, cancellationToken);

                var pronturarioSessoes = new Prontuario
                {
                    Pagina = "Sessões",
                    PacienteId = paciente.Id,
                    Conteudo = String.Empty
                };

                await _prontuarioRepository.AddAsync(pronturarioSessoes);
                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new ProntuarioActionNotification
                {
                    Pagina = "Sessões",
                    Action = ActionNotification.Created
                }, cancellationToken);

                return _mapper.Map<CreatePacienteResponse>(paciente);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao criar o paciente",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }

    }
}

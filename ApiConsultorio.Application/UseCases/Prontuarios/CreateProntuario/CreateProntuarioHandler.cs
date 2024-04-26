using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Prontuarios.CreateProntuario
{
    public class CreateProntuarioHandler : IRequestHandler<CreateProntuarioRequest, CreateProntuarioResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProntuarioRepository _prontuarioRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateProntuarioHandler(IUnitOfWork unitOfWork,
        IProntuarioRepository prontuarioRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _prontuarioRepository = prontuarioRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<CreateProntuarioResponse> Handle(CreateProntuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var prontuario = _mapper.Map<Prontuario>(request);

                await _prontuarioRepository.AddAsync(prontuario);

                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new ProntuarioActionNotification
                {
                    PacienteId = request.PacienteId,
                    Action = ActionNotification.Created
                }, cancellationToken);

                return _mapper.Map<CreateProntuarioResponse>(prontuario);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao registrar o prontuario",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

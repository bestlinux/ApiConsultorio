using ApiConsultorio.Application.Services.Notifications;
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

namespace ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento
{
    public class CreatePagamentoHandler : IRequestHandler<CreatePagamentoRequest, CreatePagamentoResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreatePagamentoHandler(IUnitOfWork unitOfWork,
        IPagamentoRepository pagamentoRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        
        public async Task<CreatePagamentoResponse> Handle(CreatePagamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pagamento = _mapper.Map<Pagamento>(request);

                await _pagamentoRepository.AddAsync(pagamento);

                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new PagamentoActionNotification
                {
                    PacienteId = request.PacienteId,
                    Action = ActionNotification.Created
                }, cancellationToken);

                return _mapper.Map<CreatePagamentoResponse>(pagamento);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao registrar o pagamento",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

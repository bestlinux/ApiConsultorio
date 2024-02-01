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

namespace ApiConsultorio.Application.UseCases.Pagamentos.UpdatePagamento
{
    public class UpdatePagamentoHandler : IRequestHandler<UpdatePagamentoRequest, UpdatePagamentoResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdatePagamentoHandler(IUnitOfWork unitOfWork,
        IPagamentoRepository pagamentoRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<UpdatePagamentoResponse> Handle(UpdatePagamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pagamento = _mapper.Map<Pagamento>(request);

                await _pagamentoRepository.UpdateAsync(pagamento);

                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new PagamentoActionNotification
                {
                    PacienteId = request.PacienteId,
                    Action = ActionNotification.Updated
                }, cancellationToken);

                return _mapper.Map<UpdatePagamentoResponse>(pagamento);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao atualizar o pagamento",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

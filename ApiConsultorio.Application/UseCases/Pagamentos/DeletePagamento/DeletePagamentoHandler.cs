using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pagamentos.DeletePagamento
{
    public class DeletePagamentoHandler : IRequestHandler<DeletePagamentoRequest, bool>
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeletePagamentoHandler(IPagamentoRepository pagamentoRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeletePagamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _pagamentoRepository.RemoveAsync(request.Id);

                return true;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao deletar o pagamento de id " + request.Id,
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return false;
            }
        }
    }
}

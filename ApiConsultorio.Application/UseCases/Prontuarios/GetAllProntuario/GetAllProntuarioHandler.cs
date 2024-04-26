using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamento;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Prontuarios.GetAllProntuario
{
    public class GetAllProntuarioHandler : IRequestHandler<GetAllProntuarioRequest, IReadOnlyCollection<GetAllProntuarioResponse>>
    {
        private readonly IProntuarioRepository _prontuarioRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetAllProntuarioHandler(IProntuarioRepository prontuarioRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _prontuarioRepository = prontuarioRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IReadOnlyCollection<GetAllProntuarioResponse>> Handle(GetAllProntuarioRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var prontuarios = await _prontuarioRepository.GetAllAsync(cancellationToken);

                return prontuarios.Select(_mapper.Map<GetAllProntuarioResponse>).ToList();
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao buscar todos os prontuarios",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

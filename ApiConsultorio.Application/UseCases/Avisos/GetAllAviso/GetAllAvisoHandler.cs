using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Pacientes.GetAllPaciente;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Avisos.GetAllAviso
{
    public class GetAllAvisoHandler : IRequestHandler<GetAllAvisoRequest, IReadOnlyCollection<GetAllAvisoResponse>>
    {
        private readonly IAvisoRepository _avisoRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetAllAvisoHandler(IAvisoRepository avisoRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _avisoRepository = avisoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IReadOnlyCollection<GetAllAvisoResponse>> Handle(GetAllAvisoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var avisos = await _avisoRepository.GetAllAsync(cancellationToken);

                return avisos.Select(_mapper.Map<GetAllAvisoResponse>).ToList();
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao buscar todos os avisos",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

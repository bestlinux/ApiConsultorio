using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMes;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamentoByPacienteMesAno;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMesAno
{
    public class GetAllAlertasByMesAnoHandler : IRequestHandler<GetAllAlertasByMesAnoRequest, IReadOnlyCollection<GetAllAlertasByMesAnoResponse>>
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetAllAlertasByMesAnoHandler(IPagamentoRepository pagamentoRepository,
         IPacienteRepository pacienteRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
            _mediator = mediator;
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IReadOnlyCollection<GetAllAlertasByMesAnoResponse>> Handle(GetAllAlertasByMesAnoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IList<Alerta> alertas = new List<Alerta>();
     
                IEnumerable<Pagamento>? pagamentos = await _pagamentoRepository.LocalizaTodosPagamentosPendentesMesAno(request.Mes, request.Ano);

                foreach (var pagamento in pagamentos)
                {
                    var entityAlerta = new Alerta
                    {
                        Descricao = string.Concat("Paciente ", pagamento.Paciente?.Nome, " possui pagamento pendente para o mês ", pagamento.Mes, " no valor de R$ ", pagamento.Valor),
                        Categoria = 2
                    };
                    alertas.Add(entityAlerta);
                }

                IEnumerable<Paciente>? pacientes = await _pacienteRepository.LocalizaAniversariantes(request.Mes);

                foreach (var paciente in pacientes)
                {
                    var entityAlerta = new Alerta
                    {
                        Descricao = string.Concat("Paciente ", paciente?.Nome, " faz aniversário no dia ", paciente?.DataNascimento.Day, " deste mês ! Não esqueça os parabéns !"),
                        Categoria = 1
                    };
                    alertas.Add(entityAlerta);
                }

                return alertas.Select(_mapper.Map<GetAllAlertasByMesAnoResponse>).ToList();
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao buscar os alertas do mes",
                    Stack = ex.StackTrace,
                }, cancellationToken);
                return null;
            }
        }
    }
}

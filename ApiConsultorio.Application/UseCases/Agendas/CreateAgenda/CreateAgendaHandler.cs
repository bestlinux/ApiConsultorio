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

namespace ApiConsultorio.Application.UseCases.Agendas.CreateAgenda
{
    public class CreateAgendaHandler : IRequestHandler<CreateAgendaRequest, CreateAgendaResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAgendaRepository _agendaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateAgendaHandler(IUnitOfWork unitOfWork,
        IAgendaRepository agendaRepository,
        IEmailService emailService,
        IPacienteRepository pacienteRepository,
        IMapper mapper,
        IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _agendaRepository = agendaRepository;
            _emailService = emailService;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateAgendaResponse> Handle(CreateAgendaRequest request, CancellationToken cancellationToken)
        {
            try
            {

                //REGRA DE REPETICAO DE EVENTO
                //TIPO REPETICAO = 1 - SEMANAL 2 - MENSAL - 3 - QUINZENAL
                //QUANTIDADE DE REPETICAO
                //TRANSFORMAR O PAGAMENTO ORBIGATORIO QUANDO FOR ATENDIDO OU FALTOU

                //INSERE A PRIMEIRA OCORRENCIA

                var agenda = _mapper.Map<Agenda>(request);

                CreateAgendaResponse createAgendaResponse = new CreateAgendaResponse();
                createAgendaResponse = _mapper.Map<CreateAgendaResponse>(agenda);

                var emailEnviado = true;

                var emailAgenda = new EmailAgenda();

                await _agendaRepository.AddAsync(agenda);

                await _unitOfWork.Commit(cancellationToken);

                //ENVIAR O EMAIL SOMENTE APOS CONFIRMAR A TRANS NO BANCO DE DADOS
                //TESTE COMMIT
                emailAgenda.InicioSessao = agenda.InicioSessao;
                emailAgenda.FimSessao = agenda.FimSessao;
                emailAgenda.PacienteEmail = await _pacienteRepository.LocalizaEmail(agenda.PacienteId);
                emailAgenda.PacienteNome = agenda.PacienteNome;
                emailAgenda.TipoRecorrencia = request.TipoRecorrencia;
                emailAgenda.NumeroRecorrencias = request.NumeroRecorrencias; 

                switch (request.TipoRecorrencia)
                {
                    //SEMANAL
                    case 5:
                        //CALCULA A DATA DA PROXIMA
                        DateTime inicioSessaoSemanal = new(request.InicioSessao.Year, request.InicioSessao.Month, request.InicioSessao.Day, request.InicioSessao.Hour, request.InicioSessao.Minute, request.InicioSessao.Second);
                        DateTime fimSessaoSemanal = new(request.FimSessao.Year, request.FimSessao.Month, request.FimSessao.Day, request.FimSessao.Hour, request.FimSessao.Minute, request.FimSessao.Second);

                        inicioSessaoSemanal = inicioSessaoSemanal.AddDays(7);
                        fimSessaoSemanal = fimSessaoSemanal.AddDays(7);

                        //INSERE AS DEMAIS
                        for (int i = 1; i < request.NumeroRecorrencias; i++)
                        {
                            var agendaRepeticao = new Agenda
                            {
                                InicioSessao = inicioSessaoSemanal,
                                FimSessao = fimSessaoSemanal,
                                PacienteId = request.PacienteId,
                                PacienteNome = request.PacienteNome,
                                StatusConsulta = request.StatusConsulta,
                                TipoConsulta = request.TipoConsulta,
                                ValorSessao = request.ValorSessao,
                                CPF = request.CPF,
                                CPFPagador = request.CPFPagador,
                            };
                            //COMMIT DAS REPETICOES
                            await _agendaRepository.AddAsync(agendaRepeticao);
                            await _unitOfWork.Commit(cancellationToken);

                            //AJUSTA AS PROXIMAS DATAS DAS SESSOES
                            inicioSessaoSemanal = inicioSessaoSemanal.AddDays(7);
                            fimSessaoSemanal = fimSessaoSemanal.AddDays(7);
                        }

                        break;

                    //QUINZENAL
                    case 6:
                        //CALCULA A DATA DA PROXIMA
                        DateTime inicioSessaoQuinzenal = new(request.InicioSessao.Year, request.InicioSessao.Month, request.InicioSessao.Day, request.InicioSessao.Hour, request.InicioSessao.Minute, request.InicioSessao.Second);
                        DateTime fimSessaoQuinzenal = new(request.FimSessao.Year, request.FimSessao.Month, request.FimSessao.Day, request.FimSessao.Hour, request.FimSessao.Minute, request.FimSessao.Second);

                        inicioSessaoQuinzenal = inicioSessaoQuinzenal.AddDays(14);
                        fimSessaoQuinzenal = fimSessaoQuinzenal.AddDays(14);

                        //INSERE AS DEMAIS
                        for (int i = 1; i < request.NumeroRecorrencias; i++)
                        {
                            var agendaRepeticao = new Agenda
                            {
                                InicioSessao = inicioSessaoQuinzenal,
                                FimSessao = fimSessaoQuinzenal,
                                PacienteId = request.PacienteId,
                                PacienteNome = request.PacienteNome,
                                StatusConsulta = request.StatusConsulta,
                                TipoConsulta = request.TipoConsulta,
                                ValorSessao = request.ValorSessao,
                                CPF = request.CPF,
                                CPFPagador = request.CPFPagador,
                            };
                            //COMMIT DAS REPETICOES
                            await _agendaRepository.AddAsync(agendaRepeticao);
                            await _unitOfWork.Commit(cancellationToken);

                            //AJUSTA AS PROXIMAS DATAS DAS SESSOES
                            inicioSessaoQuinzenal = inicioSessaoQuinzenal.AddDays(14);
                            fimSessaoQuinzenal = fimSessaoQuinzenal.AddDays(14);
                        }
                        break;
                }

                await _mediator.Publish(new AgendaActionNotification
                {
                    PacienteId = request.PacienteId,
                    Action = ActionNotification.Created
                }, cancellationToken);

                if (request.EmailAgendamento)
                {
                    try
                    {
                        await _emailService.EnviarEmailAgenda(emailAgenda);
                    }
                    catch (Exception ex)
                    {
                        emailEnviado = false;
                        await _mediator.Publish(new ErrorNotification
                        {
                            Error = "Ocorreu um erro ao enviar o email de agendamento para o paciente " + emailAgenda.PacienteEmail,
                            Stack = ex.StackTrace,
                        }, cancellationToken);
                    }
                }
                else
                {
                    emailEnviado = false;
                }

                createAgendaResponse.EmailEnviado = emailEnviado;

                return createAgendaResponse;

            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                {
                    Error = "Ocorreu um erro ao registrar o agendamento",
                    Stack = ex.StackTrace,
                }, cancellationToken);
            }
            return null;
        }
    }
}

using ApiConsultorio.Application.UseCases.Agendas.CreateAgenda;
using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using ApiConsultorio.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Agendas.Mapper
{
    public class AgendaMapper : Profile
    {
        public AgendaMapper()
        {
            CreateMap<CreateAgendaRequest, Agenda>();
            CreateMap<Agenda, CreateAgendaResponse>();
        }
    }
}

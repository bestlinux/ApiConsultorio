using ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMes;
using ApiConsultorio.Application.UseCases.Mail.SendEmailAgenda;
using ApiConsultorio.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Mail.Mapper
{
    public class EmailMapper : Profile
    {
        public EmailMapper() 
        {
            CreateMap<SendEmailAgendaRequest, EmailAgenda>();
        }
    }
}

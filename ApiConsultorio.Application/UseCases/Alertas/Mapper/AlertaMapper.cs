using ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMes;
using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamento;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamentoByPacienteMesAno;
using ApiConsultorio.Application.UseCases.Pagamentos.UpdatePagamento;
using ApiConsultorio.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Alertas.Mapper
{
    public class AlertaMapper : Profile
    {
        public AlertaMapper()
        {
            CreateMap<GetAllAlertasByMesAnoRequest, Alerta>();
            CreateMap<Alerta, GetAllAlertasByMesAnoResponse>();
        }
    }
}

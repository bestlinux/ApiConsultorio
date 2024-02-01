using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using ApiConsultorio.Application.UseCases.Pacientes.GetAllPaciente;
using ApiConsultorio.Application.UseCases.Pacientes.GetByIdPaciente;
using ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente;
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

namespace ApiConsultorio.Application.UseCases.Pagamentos.Mapper
{
    public class PagamentoMapper : Profile
    {
        public PagamentoMapper()
        {
            CreateMap<CreatePagamentoRequest, Pagamento>();
            CreateMap<Pagamento, CreatePagamentoResponse>();
            CreateMap<UpdatePagamentoRequest, Pagamento>();
            CreateMap<Pagamento, UpdatePagamentoResponse>();
            CreateMap<GetAllPagamentoRequest, Pagamento>();
            CreateMap<Pagamento, GetAllPagamentoResponse>();
            CreateMap<GetAllPagamentoByPacienteMesAnoRequest, Pagamento>();
            CreateMap<Pagamento, GetAllPagamentoByPacienteMesAnoResponse>();
        }
    }
}

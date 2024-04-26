using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamento;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamentoByPacienteMesAno;
using ApiConsultorio.Application.UseCases.Pagamentos.UpdatePagamento;
using ApiConsultorio.Application.UseCases.Prontuarios.GetAllProntuario;
using ApiConsultorio.Application.UseCases.Prontuarios.GetAllProntuarioByPaciente;
using ApiConsultorio.Application.UseCases.Prontuarios.UpdateProntuario;
using ApiConsultorio.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Prontuarios.Mapper
{
    public class ProntuarioMapper : Profile
    {
        public ProntuarioMapper()
        {
            CreateMap<GetAllProntuarioRequest, Prontuario>();
            CreateMap<Prontuario, GetAllProntuarioResponse>();
            CreateMap<GetAllProntuarioByPacienteRequest, Prontuario>();
            CreateMap<Prontuario, GetAllProntuarioByPacienteResponse>();
            CreateMap<UpdateProntuarioRequest, Prontuario>();
            CreateMap<Prontuario, UpdateProntuarioResponse>();
        }
    }
}

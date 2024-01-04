using ApiConsultorio.Application.UseCases.Categorys.UpdateCategory;
using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using ApiConsultorio.Application.UseCases.Pacientes.GetAllPaciente;
using ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente;
using ApiConsultorio.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.Mapper
{
    public sealed class PacienteMapper : Profile
    {
        public PacienteMapper() 
        {
            CreateMap<CreatePacienteRequest, Paciente>();
            CreateMap<Paciente, CreatePacienteResponse>();
            CreateMap<UpdatePacienteRequest, Paciente>();
            CreateMap<Paciente, UpdatePacienteResponse>();
            CreateMap<GetAllPacienteRequest, Paciente>();
            CreateMap<Paciente, GetAllPacienteResponse>();
        }
    }
}

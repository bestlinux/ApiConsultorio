using ApiConsultorio.Application.UseCases.Avisos.GetAllAviso;
using ApiConsultorio.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Avisos.Mapper
{
    public class AvisoMapper : Profile
    {
        public AvisoMapper() 
        {
            CreateMap<GetAllAvisoRequest, Aviso>();
            CreateMap<Aviso, GetAllAvisoResponse>();
        }
    }
}

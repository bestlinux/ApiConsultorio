using ApiConsultorio.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Categorys.UpdateCategory
{
    public sealed class UpdateCategoryMapper : Profile
    {
        public UpdateCategoryMapper()
        {
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<Category, UpdateCategoryResponse>();
        }
    }
}

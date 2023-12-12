using ApiConsultorio.Domain.Entities;
using AutoMapper;

namespace ApiConsultorio.Application.UseCases.Categorys.GetAllCategory;

public sealed class GetAllCategoryMapper : Profile
{
    public GetAllCategoryMapper()
    {
        CreateMap<Category, GetAllCategoryResponse>();
    }
}

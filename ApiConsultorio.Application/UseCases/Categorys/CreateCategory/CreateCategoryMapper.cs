using ApiConsultorio.Domain.Entities;
using AutoMapper;

namespace ApiConsultorio.Application.UseCases.Categorys.CreateCategory;

public sealed class CreateCategoryMapper : Profile
{
    public CreateCategoryMapper()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CreateCategoryResponse>();
    }
}

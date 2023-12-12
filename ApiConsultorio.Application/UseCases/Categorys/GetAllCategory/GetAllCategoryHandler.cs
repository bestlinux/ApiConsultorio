using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiConsultorio.Application.UseCases.Categorys.GetAllCategory;

public class GetAllCategoryHandler :
       IRequestHandler<GetAllCategoryRequest, IReadOnlyCollection<GetAllCategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoryHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<GetAllCategoryResponse>> Handle(GetAllCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var categorys = await _categoryRepository.GetAllAsync(cancellationToken);

        return categorys.Select(_mapper.Map<GetAllCategoryResponse>).ToList();
    }
}

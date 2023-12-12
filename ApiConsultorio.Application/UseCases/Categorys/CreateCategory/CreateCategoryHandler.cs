using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiConsultorio.Application.UseCases.Categorys.CreateCategory;

public class CreateCategoryHandler :
       IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateCategoryHandler(IUnitOfWork unitOfWork,
        ICategoryRepository categoryRepository,
        IMapper mapper,
        IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {

        var category = _mapper.Map<Category>(request);

        await _categoryRepository.AddAsync(category);

        await _unitOfWork.Commit(cancellationToken);

        await _mediator.Publish(new CategoryActionNotification
        {
            Nome = request.Nome,
            IconCSS = request.IconCSS,
            Action = ActionNotification.Created
        }, cancellationToken);

        return _mapper.Map<CreateCategoryResponse>(category);
    }
}

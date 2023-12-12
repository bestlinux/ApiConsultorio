using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Categorys.UpdateCategory
{
    public class UpdateCategoryHandler :
           IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request,
            CancellationToken cancellationToken)
        {

            var category = _mapper.Map<Category>(request);

            await _categoryRepository.UpdateAsync(category);

            await _unitOfWork.Commit(cancellationToken);

            await _mediator.Publish(new CategoryActionNotification
            {
                Nome = request.Nome,
                IconCSS = request.IconCSS,
                Action = ActionNotification.Updated
            }, cancellationToken);

            return _mapper.Map<UpdateCategoryResponse>(category);
        }
    }

}

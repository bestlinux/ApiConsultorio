using ApiConsultorio.Application.Services.Notifications;
using ApiConsultorio.Application.UseCases.Categorys.UpdateCategory;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Categorys.DeleteCategory
{
	public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, bool>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMediator _mediator;

		public DeleteCategoryHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMediator mediator)
		{
			_unitOfWork = unitOfWork;
			_categoryRepository = categoryRepository;
			_mediator = mediator;
		}

		public async Task<bool> Handle(DeleteCategoryRequest request,
		  CancellationToken cancellationToken)
		{
			await _categoryRepository.RemoveAsync(request.Id);

			await _unitOfWork.Commit(cancellationToken);

			await _mediator.Publish(new CategoryActionNotification
			{
				Id = request.Id,
				Action = ActionNotification.Deleted
			}, cancellationToken);

			return true;
		}
	}
}

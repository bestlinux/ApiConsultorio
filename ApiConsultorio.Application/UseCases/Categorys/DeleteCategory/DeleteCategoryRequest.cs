using ApiConsultorio.Application.UseCases.Categorys.UpdateCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Categorys.DeleteCategory
{
	public sealed record class DeleteCategoryRequest (int Id) : IRequest<bool>;
}

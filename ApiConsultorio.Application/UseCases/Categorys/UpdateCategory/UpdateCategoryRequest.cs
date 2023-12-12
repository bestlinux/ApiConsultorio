using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Categorys.UpdateCategory
{
    public sealed record class UpdateCategoryRequest(int Id, string Nome, string IconCSS) : IRequest<UpdateCategoryResponse>;
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Categorys.UpdateCategory
{
    public sealed class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(50);
            RuleFor(x => x.IconCSS).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}

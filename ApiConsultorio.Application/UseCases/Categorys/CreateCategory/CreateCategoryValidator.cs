using FluentValidation;

namespace ApiConsultorio.Application.UseCases.Categorys.CreateCategory;

public sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(50);
        RuleFor(x => x.IconCSS).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}

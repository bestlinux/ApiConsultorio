using MediatR;

namespace ApiConsultorio.Application.UseCases.Categorys.CreateCategory
{
    public sealed record CreateCategoryRequest(string Nome, string IconCSS) :
                                      IRequest<CreateCategoryResponse>;

}

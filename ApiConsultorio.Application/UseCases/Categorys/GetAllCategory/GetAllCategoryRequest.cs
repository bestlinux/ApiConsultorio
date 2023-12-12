using MediatR;

namespace ApiConsultorio.Application.UseCases.Categorys.GetAllCategory
{
    public sealed record GetAllCategoryRequest() :
                                      IRequest<IReadOnlyCollection<GetAllCategoryResponse>>;

}

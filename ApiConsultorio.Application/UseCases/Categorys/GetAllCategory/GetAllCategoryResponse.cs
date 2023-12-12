namespace ApiConsultorio.Application.UseCases.Categorys.GetAllCategory;

public sealed record GetAllCategoryResponse
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? IconCSS { get; set; }
}

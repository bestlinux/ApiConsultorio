namespace ApiConsultorio.Application.UseCases.Categorys.CreateCategory;

public sealed record CreateCategoryResponse
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? IconCSS { get; set; }
}

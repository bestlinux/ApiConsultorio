using ApiConsultorio.Domain.Common;
using ApiConsultorio.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace ApiConsultorio.Domain.Entities;

public sealed class Category : Entity
{
    public Category()
    { }
	[Required(ErrorMessage = "O Nome é requerido")]
	[MinLength(3)]
	[MaxLength(125)]
	public string? Nome { get; set; }
	[Required(ErrorMessage = "O Nome do ícone é requerido")]
	[MinLength(3)]
	[MaxLength(123)]
	public string? IconCSS { get; set; }
    public Category(string nome, string iconCss)
    {
        ValidateDomain(nome, iconCss);
    }
    public Category(int id, string nome, string iconCss)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido.");
        Id = id;
        ValidateDomain(nome, iconCss);
    }
    public void Update(string nome, string iconCss)
    {
        ValidateDomain(nome, iconCss);
    }
    private void ValidateDomain(string nome, string iconCss)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome é obrigatório");
        DomainExceptionValidation.When(nome.Length < 3,
           "Nome inválido");
        Nome = nome;

        DomainExceptionValidation.When(string.IsNullOrEmpty(iconCss),
           "Nome do ícone é obrigatório");
        DomainExceptionValidation.When(iconCss.Length < 3,
           "Nome do ícone inválido");
        IconCSS = iconCss;
    }

    public IEnumerable<Manga>? Mangas { get; set; }
}

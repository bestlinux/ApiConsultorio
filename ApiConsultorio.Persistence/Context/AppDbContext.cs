using ApiConsultorio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiConsultorio.Persistence.Context;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
    public DbSet<Category> Categorias { get; set; }
    public DbSet<Manga> Mangas { get; set; }

	public DbSet<Paciente> Pacientes { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		// aplica as configurações de mapeamento das entidades
		// do banco de dados contidas em uma determinada assembly
		// (conjunto de classes) ao objeto ModelBuilder durante a
		// criação do modelo.
		builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        //builder.Entity<Category>().HasKey(t => t.Id);
        //builder.Entity<Category>().
        //	Property(p => p.Nome).HasMaxLength(100).IsRequired();

        //builder.Entity<Categoria>().
        //  Property(p => p.IconCSS).HasMaxLength(100).IsRequired();

        // 1 : N => Categoria : Mangas
        builder.Entity<Paciente>().HasKey(t => t.Id);
        builder.Entity<Paciente>().Property(p => p.Nome).HasMaxLength(600).IsRequired();
        builder.Entity<Paciente>().Property(p => p.Telefone).HasMaxLength(50).IsRequired();
        builder.Entity<Paciente>().Property(p => p.DataNascimento).IsRequired();
        builder.Entity<Paciente>().Property(p => p.Sexo).IsRequired();
        builder.Entity<Paciente>().Property(p => p.Email).HasMaxLength(100).IsRequired();
        builder.Entity<Paciente>().Property(p => p.CPF).HasMaxLength(100).IsRequired();
        builder.Entity<Paciente>().Property(p => p.TipoPagamento).HasMaxLength(100).IsRequired();
        builder.Entity<Paciente>().Property(p => p.ValorSessao).HasPrecision(10, 2);
        builder.Entity<Paciente>().Property(p => p.Ativo).IsRequired();

        builder.Entity<Category>().HasKey(t => t.Id);
		builder.Entity<Category>().HasMany(c => c.Mangas)
			.WithOne(b => b.Categoria)
			.HasForeignKey(b => b.CategoriaId);

		//define os dados iniciais para a entidade Categoria
		builder.Entity<Category>().HasData(
		   new Category(1, "Aventura", "oi oi-aperture"),
		   new Category(2, "Ação", "oi oi-fire"),
		   new Category(3, "Drama", "oi oi-cloudy"),
		   new Category(4, "Romance", "oi oi-layers"),
		   new Category(5, "Ficção", "oi oi-tablet"),
           new Category(6, "asasa", "oi oi-tablet")
         );

		builder.Entity<Manga>().HasKey(t => t.Id);

		//configura o tamanho máximo das propriedades que irão gerar colunas com tamanho correspondentes 
		builder.Entity<Manga>().Property(p => p.Titulo).HasMaxLength(100).IsRequired();
		builder.Entity<Manga>().Property(p => p.Descricao).HasMaxLength(200).IsRequired();
		builder.Entity<Manga>().Property(p => p.Autor).HasMaxLength(200).IsRequired();
		builder.Entity<Manga>().Property(p => p.Editora).HasMaxLength(100).IsRequired();
		builder.Entity<Manga>().Property(p => p.Formato).HasMaxLength(100).IsRequired();
		builder.Entity<Manga>().Property(p => p.Cor).HasMaxLength(50).IsRequired();
		builder.Entity<Manga>().Property(p => p.Origem).HasMaxLength(100).IsRequired();
		builder.Entity<Manga>().Property(p => p.Imagem).HasMaxLength(250).IsRequired();

		builder.Entity<Manga>().Property(p => p.Preco).HasPrecision(10, 2);

		// Define o comportamento de exclusão de todas as chaves estrangeiras
		// no modelo de dados como ClientSetNull, para que a exclusão de uma
		// entidade relacionada resulte na definição dos valores das chaves
		// estrangeiras como null nas entidades referenciadas.
		foreach (var relationship in builder.Model.GetEntityTypes()
				.SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

	}
}

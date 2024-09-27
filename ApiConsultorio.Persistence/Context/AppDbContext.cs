using ApiConsultorio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiConsultorio.Persistence.Context;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

	public DbSet<Paciente> Pacientes { get; set; }

    public DbSet<Pagamento> Pagamentos { get; set; }

    public DbSet<Agenda> Agendas { get; set; }

    public DbSet<Tarefa> Tarefas { get; set; }

    public DbSet<Prontuario> Prontuarios { get; set; }

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
        builder.Entity<Paciente>().Property(p => p.Nome).HasMaxLength(700);
        builder.Entity<Paciente>().Property(p => p.Telefone).HasMaxLength(50);
        builder.Entity<Paciente>().Property(p => p.DataNascimento);
        builder.Entity<Paciente>().Property(p => p.Sexo);
        builder.Entity<Paciente>().Property(p => p.Email).HasMaxLength(100);
        builder.Entity<Paciente>().Property(p => p.CPF).HasMaxLength(100);
        builder.Entity<Paciente>().Property(p => p.TipoPagamento).HasMaxLength(100);
        builder.Entity<Paciente>().Property(p => p.ValorSessao).HasPrecision(10, 2);
        builder.Entity<Paciente>().Property(p => p.Ativo);

        builder.Entity<Pagamento>().HasKey(t => t.Id);

        builder.Entity<Prontuario>().HasKey(t => t.Id);

        builder.Entity<Agenda>().HasKey(t => t.Id);

        builder.Entity<Tarefa>().HasKey(t => t.Id);

		// Define o comportamento de exclusão de todas as chaves estrangeiras
		// no modelo de dados como ClientSetNull, para que a exclusão de uma
		// entidade relacionada resulte na definição dos valores das chaves
		// estrangeiras como null nas entidades referenciadas.
		foreach (var relationship in builder.Model.GetEntityTypes()
				.SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

	}
}

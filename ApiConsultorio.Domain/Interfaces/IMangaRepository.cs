
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;

namespace ApiConsultorio.Domain.Interfaces;

public interface IMangaRepository : IRepository<Manga>
{
    Task<IEnumerable<Manga>>
        GetMangasPorCategoriaAsync(int categoriaId);

    Task<IEnumerable<Manga>>
        LocalizaMangaComCategoriaAsync(string criterio);

    IQueryable<Manga> GetMangasQueryable();   
}

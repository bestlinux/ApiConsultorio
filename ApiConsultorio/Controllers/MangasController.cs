using ApiConsultorio.ApiPaginacao;
using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMangas.Controllers;

[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
public class MangasController : ControllerBase
{
	private readonly IMediator _mediator;
	//private readonly IMapper _mapper;

	public MangasController(IMediator mediator)
    {
		_mediator = mediator;
		//_mapper = mapper;
	}

    /*[HttpGet("paginacao")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Manga>>> GetMangasPaginacao([FromQuery] 
                                                    Paginacao paginacao)
    {
        var mangasPaginados = _mangaRepository.GetMangasQueryable();

        if (mangasPaginados is null)
        {
            return NotFound("Mangás não existem");
        }

        double quantidadeRegistrosTotal = await mangasPaginados.CountAsync();
        double totalPaginas = Math.Ceiling(quantidadeRegistrosTotal / paginacao.QuantidadePorPagina);

        var result = await mangasPaginados.Paginar(paginacao).ToListAsync();
        //var mangasDto = _mapper.Map<IEnumerable<Manga>>(result);

        var response = new MangaPaginacaoReponse
        {
            Mangas = result.ToList(),
            TotalPaginas = (int)totalPaginas
        };

        return Ok(response);
    }*/

    [HttpGet]
    // Atributos de ação que fornecem informações sobre os possíveis códigos de status HTTP
    // que podem ser retornados pelo endpoint da Web API.
    // Esses atributos indicam os códigos de status de resposta esperados para esse endpoint
    // específico e ajudam a documentar e definir a semântica da API
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Manga>>> GetAll()
    {
        /*var result = await _mediator.Send(new GetAllMangaQuery());

        if (result is null)
        {
            return NotFound("Mangás não encontrados");
        }

		//var mangasDto = _mapper.Map<IEnumerable<MangaDTO>>(mangas);
		return Ok(result);*/
        return null;
	}

    /*[HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var manga = await _mangaRepository.GetByIdAsync(id);

        if (manga is null) return NotFound($"Manga com {id} não encontrado");

        return Ok(manga);
    }*/

    /*[HttpGet]
    [Route("get-mangas-by-category/{categoryId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMangasByCategory(int categoryId)
    {
        var mangas = await _mangaRepository.GetMangasPorCategoriaAsync(categoryId);

        if (!mangas.Any()) return NotFound();

        return Ok(mangas);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add(Manga manga)
    {
        if (!ModelState.IsValid) return BadRequest();

        //var manga = _mapper.Map<Manga>(mangaDto);
        await _mangaRepository.AddAsync(manga);

        return Ok(manga);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, Manga manga)
    {
        if (id != manga.Id) return BadRequest();

        if (!ModelState.IsValid) return BadRequest();

        await _mangaRepository.UpdateAsync(manga);

        return Ok(manga);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove(int id)
    {
        var manga = await _mangaRepository.GetByIdAsync(id);
        if (manga is null) return NotFound();
        await _mangaRepository.RemoveAsync(manga.Id);
        return Ok();
    }

    [HttpGet]
    [Route("search/{mangaTitulo}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Manga>>> Search(string mangaTitulo)
    {
           var mangas = await _mangaRepository.SearchAsync(m => m.Titulo.Contains(mangaTitulo));
           
           if (mangas is null)
                 return NotFound("Nenhum mangá foi encontrado");   

           return Ok(mangas);        
    }

    [HttpGet]
    [Route("search-manga-with-category/{criterio}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<MangaCategoria>>> SearchMangaWithCategory(string criterio)
    {
        var mangas = await _mangaRepository.LocalizaMangaComCategoriaAsync(criterio);

        if (!mangas.Any())
            return NotFound("Nenhum mangá foi encontrado");

        return Ok(mangas);
    }*/
}

using ApiConsultorio.Application.UseCases.Categorys.CreateCategory;
using ApiConsultorio.Application.UseCases.Categorys.DeleteCategory;
using ApiConsultorio.Application.UseCases.Categorys.GetAllCategory;
using ApiConsultorio.Application.UseCases.Categorys.UpdateCategory;
using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace ApiMangas.Controllers;

[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
public class CategoriasController : ControllerBase
{
	private readonly IMediator _mediator;

	public CategoriasController(IMediator mediator)
	{
		_mediator = mediator;
	}
    [HttpDelete]
	public async Task<ActionResult> Delete([FromBody] DeleteCategoryRequest deleteCategory, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(deleteCategory, cancellationToken);
		return Ok(result);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryRequest listCategory, CancellationToken cancellationToken )
	{
		var result = await _mediator.Send(listCategory, cancellationToken);
		return Ok(result);
	}

	[HttpPut]
    public async Task<ActionResult<CreateCategoryResponse>> Put([FromBody] UpdateCategoryRequest updateCategory, CancellationToken cancellationToken)
    {
		var validator = new UpdateCategoryValidator();
		var validationResult = await validator.ValidateAsync(updateCategory);

		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var result = await _mediator.Send(updateCategory, cancellationToken);

		return Ok(result);
	}

	/*[HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        var categorias = await _categoriaRepository.GetAllAsync();
        if (categorias is null)
        {
            return NotFound("Categorias não existem");
        }
        var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        return Ok(categoriasDto);
    }*/

	/*[HttpGet("{id:int}", Name = "GetCategoria")]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria is null)
        {
            return NotFound("Categoria não encontrada");
        }

        var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
        return Ok(categoriaDto);
    }*/

	/*[HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto)
    {
        if (categoriaDto == null)
            return BadRequest("Dados inválidos");

        var categoria = _mapper.Map<Categoria>(categoriaDto);

        await _categoriaRepository.AddAsync(categoria);

        return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDto.Id },
            categoriaDto);
    }*/

	/*[HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
    {
        if (id != categoriaDto.Id)
            return BadRequest();

        if (categoriaDto == null)
            return BadRequest();

        var categoria = _mapper.Map<Categoria>(categoriaDto);

        await _categoriaRepository.UpdateAsync(categoria);

        return Ok(categoriaDto);
    }*/

	/*[HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria == null)
        {
            return NotFound("Categoria não encontrada");
        }

        await _categoriaRepository.RemoveAsync(id);

        return Ok(categoria);
    }*/

	[HttpPost]
	public async Task<ActionResult<CreateCategoryResponse>> Create(CreateCategoryRequest request,
														 CancellationToken cancellationToken)
	{
		var validator = new CreateCategoryValidator();
		var validationResult = await validator.ValidateAsync(request);

		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var result = await _mediator.Send(request, cancellationToken);
		return Ok(result);
	}


	/*[HttpPost]
	public async Task<ActionResult<CreateCategoryResponse>> Create(CreateCategoryRequest request,
														CancellationToken cancellationToken)
	{
		var validator = new CreateCategoryValidator();
		var validationResult = await validator.ValidateAsync(request);

		if (!validationResult.IsValid)
		{
		    return BadRequest(validationResult.Errors);
		}

		var response = await _mediator.Send(request, cancellationToken);

		return Ok(response);
	}*/
}

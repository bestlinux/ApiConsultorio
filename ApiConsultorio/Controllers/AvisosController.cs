using ApiConsultorio.Application.Shared.Validator;
using ApiConsultorio.Application.UseCases.Agendas.DeleteAgenda;
using ApiConsultorio.Application.UseCases.Agendas.GetAllAgenda;
using ApiConsultorio.Application.UseCases.Avisos.CreateAviso;
using ApiConsultorio.Application.UseCases.Avisos.GetAllAviso;
using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultorio.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class AvisosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AvisosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAvisoRequest listAviso, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listAviso, cancellationToken);
            return Ok(result);
        }

        /*[HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id, CancellationToken cancellationToken)
        {
            DeleteAvisoRequest avisoRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(avisoRequest, cancellationToken);
            return Ok(result);
        }*/

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Create(CreateAvisoRequest request,
                                                        CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

    }
}

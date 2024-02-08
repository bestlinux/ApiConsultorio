using ApiConsultorio.Application.Shared.Validator;
using ApiConsultorio.Application.UseCases.Agendas.CreateAgenda;
using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultorio.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgendaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateAgendaResponse>> Create(CreateAgendaRequest request,
                                                       CancellationToken cancellationToken)
        {
            var validator = new AgendaCreateValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}

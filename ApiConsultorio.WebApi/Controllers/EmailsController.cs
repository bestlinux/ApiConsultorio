using ApiConsultorio.Application.Shared.Validator;
using ApiConsultorio.Application.UseCases.Agendas.CreateAgenda;
using ApiConsultorio.Application.UseCases.Mail.SendEmailAgenda;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Create(SendEmailAgendaRequest request,
                                                      CancellationToken cancellationToken)
        {
            var validator = new EmailCreateValidator();
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

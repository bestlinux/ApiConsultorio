using ApiConsultorio.Application.Shared.Validator;
using ApiConsultorio.Application.UseCases.Agendas.CreateAgenda;
using ApiConsultorio.Application.UseCases.Agendas.DeleteAgenda;
using ApiConsultorio.Application.UseCases.Agendas.DeleteAgendaByTipoConsulta;
using ApiConsultorio.Application.UseCases.Agendas.DeleteAgendaPacienteByRecorrencia;
using ApiConsultorio.Application.UseCases.Agendas.GetAllAgenda;
using ApiConsultorio.Application.UseCases.Agendas.UpdateAgenda;
using ApiConsultorio.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class AgendasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgendasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id, CancellationToken cancellationToken)
        {
            DeleteAgendaRequest agendaRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(agendaRequest, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("delete-agenda-paciente-by-recorrencia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveByRecorrencia([FromQuery] DeleteAgendaPacienteByRecorrenciaRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("delete-by-tipoconsulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveByTipoConsulta(int tipoConsulta, CancellationToken cancellationToken)
        {
            DeleteAgendaByTipoConsultaRequest agendaRequest = new()
            {
                TipoConsulta = tipoConsulta
            };
            var result = await _mediator.Send(agendaRequest, cancellationToken);
            return Ok(result);
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateAgendaResponse>> UpdateAgendaAsync(UpdateAgendaRequest updateAgenda, CancellationToken cancellationToken)
        {
            var validator = new AgendaUpdateValidator();
            var validationResult = await validator.ValidateAsync(updateAgenda, cancellationToken);

            if (!validationResult.IsValid)
            {
                ErrorDto error = new();

                foreach (var item in validationResult.Errors)
                {
                    ErrorItem errorItem = new()
                    {
                        Message = item.ErrorMessage,
                        Tag = item.PropertyName
                    };
                    error.Errors.Add(errorItem);
                }

                return BadRequest(error);
            }

            var result = await _mediator.Send(updateAgenda, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAgendaRequest listAgenda, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listAgenda, cancellationToken);
            return Ok(result);
        }

    }
}

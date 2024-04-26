using ApiConsultorio.Application.Shared.Validator;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamento;
using ApiConsultorio.Application.UseCases.Pagamentos.UpdatePagamento;
using ApiConsultorio.Application.UseCases.Prontuarios.GetAllProntuario;
using ApiConsultorio.Application.UseCases.Prontuarios.GetAllProntuarioByPaciente;
using ApiConsultorio.Application.UseCases.Prontuarios.UpdateProntuario;
using ApiConsultorio.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultorio.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class ProntuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProntuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAllProntuarioResponse>> GetAll([FromQuery] GetAllProntuarioRequest listaProntuario, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listaProntuario, cancellationToken);
            return Ok(result);
        }

        [HttpGet("search-prontuarios-paciente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAllProntuarioByPacienteResponse>> GetProntuarioByPaciente([FromQuery] GetAllProntuarioByPacienteRequest listaProntuario, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listaProntuario, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateProntuarioResponse>> UpdateProntuarioAsync(UpdateProntuarioRequest updateProntuario, CancellationToken cancellationToken)
        {
            var validator = new ProntuarioUpdateValidator();
            var validationResult = await validator.ValidateAsync(updateProntuario, cancellationToken);

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

            var result = await _mediator.Send(updateProntuario, cancellationToken);

            return Ok(result);
        }
    }
}

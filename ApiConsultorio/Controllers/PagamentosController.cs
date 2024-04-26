using ApiConsultorio.Application.Shared.Validator;
using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using ApiConsultorio.Application.UseCases.Pacientes.DeletePaciente;
using ApiConsultorio.Application.UseCases.Pacientes.GetAllPaciente;
using ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente;
using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using ApiConsultorio.Application.UseCases.Pagamentos.DeletePagamento;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamento;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamentoByPacienteMesAno;
using ApiConsultorio.Application.UseCases.Pagamentos.UpdatePagamento;
using ApiConsultorio.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultorio.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id, CancellationToken cancellationToken)
        {
            DeletePagamentoRequest pagamentoRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(pagamentoRequest, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreatePagamentoResponse>> Create(CreatePagamentoRequest request,
                                                        CancellationToken cancellationToken)
        {
            var validator = new PagamentoCreateValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAllPagamentoResponse>> GetAll([FromQuery] GetAllPagamentoRequest listaPagamento, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listaPagamento, cancellationToken);
            return Ok(result);
        }

        [HttpGet("search-pagamentos-paciente-mes-ano")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAllPagamentoByPacienteMesAnoResponse>> GetAllPagamentoByPacienteMesAno([FromQuery] GetAllPagamentoByPacienteMesAnoRequest listaPagamento, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listaPagamento, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdatePagamentoResponse>> UpdatePagamentoAsync(UpdatePagamentoRequest updatePagamento, CancellationToken cancellationToken)
        {
            var validator = new PagamentoUpdateValidator();
            var validationResult = await validator.ValidateAsync(updatePagamento, cancellationToken);

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

            var result = await _mediator.Send(updatePagamento, cancellationToken);

            return Ok(result);
        }
    }
}

using ApiConsultorio.Application.Shared.Validator;
using ApiConsultorio.Application.UseCases.Categorys.CreateCategory;
using ApiConsultorio.Application.UseCases.Categorys.GetAllCategory;
using ApiConsultorio.Application.UseCases.Categorys.UpdateCategory;
using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using ApiConsultorio.Application.UseCases.Pacientes.GetAllPaciente;
using ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente;
using ApiConsultorio.Domain.Entities;
using Correios.NET;
using Correios.NET.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultorio.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]

    public class PacientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreatePacienteResponse>> Create(CreatePacienteRequest request,
                                                         CancellationToken cancellationToken)
        {
            var validator = new PacienteCreateValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPacienteRequest listaPaciente, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listaPaciente, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdatePacienteResponse>> Put([FromBody] UpdatePacienteRequest updatePaciente, CancellationToken cancellationToken)
        {
            var validator = new PacienteUpdateValidator();
            var validationResult = await validator.ValidateAsync(updatePaciente, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _mediator.Send(updatePaciente, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [Route("buscacep/{cep}")]
        public ActionResult<Endereco> BuscaCEP(string cep)
        {
            CorreiosService correiosService = new();

            var addresses = correiosService.GetAddresses(cep);

            Endereco endereco = new();

            foreach (var address in addresses)
            {
                endereco.Logradouro = address.Street;
                endereco.Bairro = address.District;
                endereco.Estado = address.State;
                endereco.Cidade = address.City;

            }
            return Ok(endereco);
        }

    }
}

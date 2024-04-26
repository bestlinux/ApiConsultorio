using ApiConsultorio.Application.Shared.Validator;
using ApiConsultorio.Application.UseCases.Categorys.CreateCategory;
using ApiConsultorio.Application.UseCases.Categorys.GetAllCategory;
using ApiConsultorio.Application.UseCases.Categorys.UpdateCategory;
using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using ApiConsultorio.Application.UseCases.Pacientes.DeletePaciente;
using ApiConsultorio.Application.UseCases.Pacientes.GetAllPaciente;
using ApiConsultorio.Application.UseCases.Pacientes.GetByIdPaciente;
using ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente;
using ApiConsultorio.Domain.Entities;
using Correios.NET;
using Correios.NET.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace ApiConsultorio.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]

    public class PacientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAllPacienteResponse>> GetAll([FromQuery] GetAllPacienteRequest listaPaciente, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listaPaciente, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetByIdPacienteResponse>> GetById(int id, CancellationToken cancellationToken)
        {
            GetByIdPacienteRequest pacienteRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(pacienteRequest, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeletePacienteResponse>> Remove(int id, CancellationToken cancellationToken)
        {
            DeletePacienteRequest pacienteRequest = new()
            {
                Id = id
            };
            var result = await _mediator.Send(pacienteRequest, cancellationToken);

            if ((bool)!result.Success)
            {
                return BadRequest(result.Error);
            }
            else
                return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdatePacienteResponse>> UpdatePacienteAsync(UpdatePacienteRequest updatePaciente, CancellationToken cancellationToken)
        {
            var validator = new PacienteUpdateValidator();
            var validationResult = await validator.ValidateAsync(updatePaciente, cancellationToken);            

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

            var result = await _mediator.Send(updatePaciente, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

using ApiConsultorio.Application.UseCases.Alertas.GetAllAlertasByMes;
using ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamentoByPacienteMesAno;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultorio.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class AlertasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlertasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search-alertas-mes-ano")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAllAlertasByMesAnoResponse>> GetAllAlertasByMesAno([FromQuery] GetAllAlertasByMesAnoRequest listaAlerta, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(listaAlerta, cancellationToken);
            return Ok(result);
        }
    }
}

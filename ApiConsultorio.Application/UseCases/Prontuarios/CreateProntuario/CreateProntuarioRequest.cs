using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Prontuarios.CreateProntuario
{
    public class CreateProntuarioRequest : IRequest<CreateProntuarioResponse>
    {
        public int? PacienteId { get; set; }

        public string? Pagina { get; set; }

        public string? Conteudo { get; set; }
    }
}

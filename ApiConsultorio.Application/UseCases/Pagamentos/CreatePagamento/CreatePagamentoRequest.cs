using ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento
{
    public class CreatePagamentoRequest : IRequest<CreatePagamentoResponse>
    {
        public int? Status { get; set; }

        public double? Valor { get; set; }

        public string? Observacao { get; set; }

        public int? Mes { get; set; }

        public int? PacienteId { get; set; }

        public int Ano { get; set; }
    }
}

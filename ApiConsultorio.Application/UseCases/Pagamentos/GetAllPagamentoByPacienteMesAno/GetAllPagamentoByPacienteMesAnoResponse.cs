using ApiConsultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pagamentos.GetAllPagamentoByPacienteMesAno
{
    public class GetAllPagamentoByPacienteMesAnoResponse
    {
        public int Id { get; set; }
        public Paciente? Paciente { get; set; }

        public int TipoPagamento { get; set; }

        public double? Valor { get; set; }

        public string? Observacao { get; set; }

        public int? Mes { get; set; }

        public int? PacienteId { get; set; }

        public int Ano { get; set; }
    }
}

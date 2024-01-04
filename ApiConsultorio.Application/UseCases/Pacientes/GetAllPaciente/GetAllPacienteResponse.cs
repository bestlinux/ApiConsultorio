using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.GetAllPaciente
{
    public sealed record GetAllPacienteResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        //ENDERECO
        public string? CEP { get; set; }

        public string? Logradouro { get; set; }

        public string? NumeroLogradouro { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        //MENSAL
        //AVULSO
        //GRATUITO
        public string TipoPagamento { get; set; }

        public decimal? ValorSessao { get; set; }

        public int? DiaVencimento { get; set; }

        public bool? StatusPagamento { get; set; }

        public bool Ativo { get; set; }

    }
}

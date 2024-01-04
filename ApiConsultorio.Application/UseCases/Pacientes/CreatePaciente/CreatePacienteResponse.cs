using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.CreatePaciente
{
    public class CreatePacienteResponse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo sexo é obrigatório")]
        public int Sexo { get; set; }

        [Required(ErrorMessage = "O campo data nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo cpf é obrigatório")]
        public string CPF { get; set; }

        public int Pais { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public string? Complemento { get; set; }

        //MENSAL
        //AVULSO
        //GRATUITO
        public int TipoPagamento { get; set; }

        public double? ValorSessao { get; set; }

        public int? DiaVencimento { get; set; }

        public bool? StatusPagamento { get; set; }

        public int Ativo { get; set; }
        /*[Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string Cidade { get; set; }*/
    }
}

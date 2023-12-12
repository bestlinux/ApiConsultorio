using ApiConsultorio.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ApiConsultorio.Domain.Entities
{
    public class Paciente : Entity
    {
        public Paciente() { }

        [Required(ErrorMessage = "O nome é requerido")]
        [MinLength(3)]
        [MaxLength(500)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatória")]
        [MinLength(5)]
        [MaxLength(50)]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O nascimento é obrigatório")]
        [DisplayName("Nascimento")]
        public DateTime Nascimento { get; set; }

        public string Sexo { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        //ENDERECO
        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string NumeroLogradouro { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        //MENSAL
        //AVULSO
        public int TipoPagamento { get; set; }

        public double ValorSessao { get; set; }

        public int DiaVencimento { get; set; }

        public bool StatusPagamento { get; set; }

        public bool Ativo { get; set; }

    }
}

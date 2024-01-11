﻿using ApiConsultorio.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConsultorio.Domain.Entities
{
    public sealed class Paciente : Entity
    {
        public Paciente() { }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }
        public int Sexo { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public int Pais { get; set; }

        //ENDERECO
        public string? CEP { get; set; }

        public string? Logradouro { get; set; }

        public string? NumeroLogradouro { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string Estado { get; set; }

        //MENSAL
        //AVULSO
        //GRATUITO
        public string TipoPagamento { get; set; }

        public decimal? ValorSessao { get; set; }

        public int? DiaVencimento { get; set; }

        public int? StatusPagamento { get; set; }

        public int Ativo { get; set; }

    }
}

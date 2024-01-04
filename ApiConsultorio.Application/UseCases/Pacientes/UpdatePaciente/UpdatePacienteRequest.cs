using ApiConsultorio.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pacientes.UpdatePaciente
{
    public sealed record UpdatePacienteRequest (int Id, string Nome, string Telefone, DateTime Nascimento, string Sexo, string Email, string CPF, string? CEP, string? Logradouro, string? NumeroLogradouro, string? Complemento, string? Bairro, string? Cidade, string TipoPagamento, decimal? ValorSessao, int? DiaVencimento, bool Ativo, bool StatusPagamento) : IRequest<UpdatePacienteResponse>;
}

using ApiConsultorio.Application.UseCases.Pagamentos.CreatePagamento;
using ApiConsultorio.Application.UseCases.Prontuarios.CreateProntuario;
using ApiConsultorio.Application.UseCases.Prontuarios.UpdateProntuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Shared.Validator
{
    public class ProntuarioCreateValidator : AbstractValidator<CreateProntuarioRequest>
    {
        public ProntuarioCreateValidator()
        {
            RuleFor(x => x.Conteudo).NotEmpty();
            RuleFor(x => x.Pagina).NotEmpty();
        }
    }

    public class ProntuarioUpdateValidator : AbstractValidator<UpdateProntuarioRequest>
    {
        public ProntuarioUpdateValidator()
        {
            RuleFor(x => x.Conteudo).NotEmpty();
            RuleFor(x => x.Pagina).NotEmpty();
        }
    }
}

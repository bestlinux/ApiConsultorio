using ApiConsultorio.Application.UseCases.Avisos.GetAllAviso;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Avisos.CreateAviso
{
    public sealed record CreateAvisoRequest : IRequest<bool>;
}

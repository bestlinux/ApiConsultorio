using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Pagamentos.DeletePagamento
{
    public class DeletePagamentoRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

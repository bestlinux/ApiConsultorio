using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Services.Notifications
{
    internal class PagamentoActionNotification : INotification
    {
        public int? PacienteId { get; set; }
        public ActionNotification Action { get; set; }
    }
}

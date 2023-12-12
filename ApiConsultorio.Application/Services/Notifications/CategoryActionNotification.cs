using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Services.Notifications
{
    public class CategoryActionNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string IconCSS { get; set; }
        public ActionNotification Action { get; set; }
    }
}

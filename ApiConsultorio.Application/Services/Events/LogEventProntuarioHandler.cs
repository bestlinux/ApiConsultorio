using ApiConsultorio.Application.Services.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Services.Events
{
    public class LogEventProntuarioHandler : INotificationHandler<ProntuarioActionNotification>,
                 INotificationHandler<ErrorNotification>
    {
        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERROR : '{notification.Error} \n {notification.Stack}'");
            }, cancellationToken);
        }

        Task INotificationHandler<ProntuarioActionNotification>.Handle(ProntuarioActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Prontuario do tipo " + notification.Pagina + " para o paciente {notification.PacienteId} - foi {notification.Action.ToString().ToLower()} com sucesso !");
            }, cancellationToken);
        }
    }
}

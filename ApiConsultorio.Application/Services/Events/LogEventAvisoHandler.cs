using ApiConsultorio.Application.Services.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Services.Events
{
    public class LogEventAvisoHandler : INotificationHandler<AvisoActionNotification>,
                 INotificationHandler<ErrorNotification>
    {
        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERROR : '{notification.Error} \n {notification.Stack}'");
            }, cancellationToken);
        }

        Task INotificationHandler<AvisoActionNotification>.Handle(AvisoActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"AAviso {notification.Id} - foi {notification.Action.ToString().ToLower()} com sucesso !");
            }, cancellationToken);
        }
    }
}

using ApiConsultorio.Application.Services.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Services.Events
{
    public class LogEventCategoryHandler :
                 INotificationHandler<CategoryActionNotification>,
                 INotificationHandler<ErrorNotification>
    {
        public Task Handle(CategoryActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Category {notification.Nome} - {notification.IconCSS} was {notification.Action.ToString().ToLower()} successfuly");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERROR : '{notification.Error} \n {notification.Stack}'");
            });
        }
    }
}

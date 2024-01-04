﻿using ApiConsultorio.Application.Services.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.Services.Events
{
    public class LogEventPacienteHandler :
                 INotificationHandler<PacienteActionNotification>,
                 INotificationHandler<ErrorNotification>
    {
        public Task Handle(PacienteActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Paciente {notification.Nome} - foi {notification.Action.ToString().ToLower()} com sucesso !");
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

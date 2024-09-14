using ApiConsultorio.Domain.Entities;
using ApiConsultorio.Domain.Interfaces;
using ApiConsultorio.Infra.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Ical.Net.DataTypes;
using Ical.Net.CalendarComponents;
using Ical.Net;
using Ical.Net.Serialization;
using FluentEmail.Smtp;
using FluentEmail.Core;

namespace ApiConsultorio.Infra.ServiceEmail
{
    public class EmailService(EmailSettings emailSettings) : IEmailService
    {
        private readonly EmailSettings _settings = emailSettings;

        public async Task<bool> EnviarEmailAgenda(EmailAgenda emailAgenda)
        {

            var AttendeeName = _settings.Anfitriao;
            //PARTICIPANTE EMAIL
            var AttendeeEmail = _settings.From;
            var Name = _settings.Anfitriao;
            var Start = new CalDateTime(Convert.ToDateTime(emailAgenda.InicioSessao));
            var End = new CalDateTime(Convert.ToDateTime(emailAgenda.FimSessao));
            var Location = _settings.Localizacao;
            var Description = _settings.Subject;

            List<Attendee> attendees = [];

            var attendee = new
            Ical.Net.DataTypes.Attendee()
            {
                CommonName = AttendeeName,
                ParticipationStatus = "REQ-PARTICIPANT",
                Rsvp = true,
                Role = "REQ-PARTICIPANT",
                Value = new Uri($"mailto:{AttendeeEmail}")
            };

            attendees.Add(attendee);

            var e = new CalendarEvent
            {
                Summary = Name,
                IsAllDay = true,

                Organizer = new Organizer()
                {
                    CommonName = _settings.Anfitriao,
                    Value = new Uri("mailto:" + _settings.From)
                },
                Attendees = attendees,
                Status = "Confirmed",
                Sequence = 0,
                Start = new CalDateTime(Start),
                End = new CalDateTime(End),
                Transparency = TransparencyType.Opaque,
                Location = Location,
                Description = Description
            };

            var calendar = new Calendar();
            calendar.AddProperty("X-MS-OLK-FORCEINSPECTOROPEN", "TRUE");
            calendar.AddProperty("METHOD", "REQUEST");

            calendar.Events.Add(e);

            var serializer = new CalendarSerializer();
            var serializedCalendar = serializer.SerializeToString(calendar);

            var bytesCalendar = Encoding.ASCII.GetBytes(serializedCalendar);
            MemoryStream ms = new(bytesCalendar);

            using (ms)
            {
                ms.Position = 0;

                SmtpClient smtp = new()
                {
                    Host = _settings.Host,
                    EnableSsl = true,
                    Port = int.Parse(_settings.Port),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //Enter the user name and password of your sending SMTP server here
                    Credentials = new NetworkCredential(_settings.Username, _settings.Password)
                };
                //Set default sending information
                FluentEmail.Core.Email.DefaultSender = new SmtpSender(smtp);

                var email = FluentEmail.Core.Email
                    //Sender
                    .From(_settings.From)
                    //Addressee
                    .To(emailAgenda.PacienteEmail)
                    //Message title
                    .Subject(_settings.Subject)
                    //Email content
                    .Body(_settings.Subject);

                var attachment = new FluentEmail.Core.Models.Attachment
                {
                    Data = ms,
                    ContentType = "text/calendar",
                    Filename = "invite.ics",
                };
                email.Attach(attachment);

                var response = await email.SendAsync();

                return response.Successful;
            }
        }
    }
}

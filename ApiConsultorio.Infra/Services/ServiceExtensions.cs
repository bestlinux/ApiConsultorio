using ApiConsultorio.Domain.Interfaces;
using ApiConsultorio.Infra.Configuration;
using ApiConsultorio.Infra.ServiceEmail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Infra.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureEmail(this IServiceCollection services, IConfiguration configuration)
        {
            var host = configuration["Email:Host"];
            var port = configuration["Email:Port"];
            var password = "rtde pggf tbcm epxr";
            var username = "aparecidagago@gmail.com";
            var from = configuration["Email:From"];
            var subject = configuration["Email:Subject"];
            var anfitriao = configuration["Email:Anfitriao"];
            var localizacao = configuration["Email:Localizacao"];

            var settings = new EmailSettings
            {
                Host = host,
                Port = port,
                Password = password,
                Username = username,
                From = from,
                Subject = subject,
                Anfitriao = anfitriao,
                Localizacao = localizacao
            };
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton(settings);
        }
    }
}

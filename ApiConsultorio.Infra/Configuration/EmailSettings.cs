using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Infra.Configuration
{
    public class EmailSettings
    {
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }

        public string? From { get; set; }

        public string? Subject { get; set; }

        public string? Anfitriao { get; set; }

        public string? Localizacao { get; set; }
    }
}

using ApiConsultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Interfaces
{
    public interface IEmailService
    {
        Task<bool> EnviarEmailAgenda(EmailAgenda email);
    }
}
